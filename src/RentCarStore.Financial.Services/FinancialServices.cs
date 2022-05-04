using EasyNetQ;
using RentCarStore.Financial.Data.Repositories;
using RentCarStore.Financial.Domain;
using RentCarStore.Financial.Domain.Enums;
using RentCarStore.Financial.Services.Dtos;
using RentCartStore.Core.Messaging.IntegrationMessages;

namespace RentCarStore.Financial.Services
{
    public interface IFinancialServices
    {
        Task<RentRecord> Get(Guid id);
        Task<List<RentRecord>> GetByCustomerId(Guid customerId);
        Task ProcessRentRequest(RentRequestIntegrationMessage rentRequest);
        Task AnalyseRentRequests();
    }

    public class FinancialServices : IFinancialServices
    {
        private readonly IFinancialRepository _financialRepository;
        private readonly IBus _bus;

        public FinancialServices(IFinancialRepository financialRepository, IBus bus)
        {
            _financialRepository = financialRepository;
            _bus = bus;
        }

        private static string GenerateRentCode(Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 7)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task AnalyseRentRequests()
        {
            var rentRecords = await _financialRepository.GetAllUnanalyzedRents();

            Random rnd = new Random();

            foreach (var rentRecord in rentRecords)
            {
                var status = rnd.Next(1, 3);

                if (status == 1)
                {
                    rentRecord.ApproveRent();
                    _bus.PubSub.Publish(new RentRequestApprovedIntegrationMessage()
                    {
                        CarId = rentRecord.CarId,
                        CustomerId = rentRecord.CustomerId, 
                        StartRentDate = rentRecord.Start,
                        EndRentDate = rentRecord.End,
                        RentCode = GenerateRentCode(rnd)
                    });
                }
                else
                {
                    rentRecord.DenyRent();
                    _bus.PubSub.Publish(new RentRequestDeniedIntegrationMessage()
                    {
                        CarId = rentRecord.CarId,
                        CustomerId = rentRecord.CustomerId,
                        DenyReason = "Seems that the customer has financial issues."
                    });
                }
            }

            await _financialRepository.CommitAsync();
        }

        public async Task<RentRecord> Get(Guid id)
            => await _financialRepository.Get(id);

        public async Task<List<RentRecord>> GetByCustomerId(Guid customerId)
            => await _financialRepository.GetByCustomerId(customerId);

        public async Task ProcessRentRequest(RentRequestIntegrationMessage rentRequest)
        {
            RentRecord rentRecord = new RentRecord();

            rentRecord.Start = rentRequest.StartRentDate;
            rentRecord.End = rentRequest.EndRentDate;
            rentRecord.CarId = rentRequest.CarId;
            rentRecord.CustomerId = rentRequest.CustomerId;

            await _financialRepository.Create(rentRecord);
            await _financialRepository.CommitAsync();
        }
    }
}