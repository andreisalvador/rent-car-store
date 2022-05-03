using RentCarStore.Financial.Domain;
using RentCarStore.Financial.Services.Dtos;

namespace RentCarStore.Financial.Services
{
    public interface IFinancialServices
    {
        Task Create(RentDto newRent);
        Task<RentRecord> Get(Guid id);
        Task<RentRecord> GetByCustomerId(Guid customerId);
    }

    public class FinancialServices : IFinancialServices
    {
        public Task Create(RentDto newRent)
        {
            throw new NotImplementedException();
        }

        public Task<RentRecord> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RentRecord> GetByCustomerId(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}