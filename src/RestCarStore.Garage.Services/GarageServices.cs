using EasyNetQ;
using RentCarStore.Garage.Data.Repositories;
using RentCartStore.Core.Messaging.IntegrationMessages;
using RestCarStore.Garage.Domain;
using RestCarStore.Garage.Services.Dtos;

namespace RestCarStore.Garage.Services
{
    public interface IGarageServices
    {
        Task<Car> Create(CarDto newCar);
        Task<Car> Get(Guid id);
        Task RequestCar(RentRequestDto rentRequest);
        Task ApproveRent(ApprovedRentRequestDto rentRequest);
    }
    public class GarageServices : IGarageServices
    {
        private readonly IBus _bus;
        private readonly IGarageRepository _garageRepository;

        public GarageServices(IBus bus, IGarageRepository garageRepository)
        {
            _bus = bus;
            _garageRepository = garageRepository;
        }

        public async Task ApproveRent(ApprovedRentRequestDto rentRequest)
        {
            Car carRented = await _garageRepository.GetCarById(rentRequest.CarId);

            carRented.RentalStatus.RentedBy = rentRequest.CustomerId;
            carRented.RentalStatus.ReturnsIn = rentRequest.RentEnd;

            _garageRepository.Update(carRented.RentalStatus);

            await _garageRepository.CommitAsync();
        }

        public async Task<Car> Create(CarDto newCarDto)
        {
            Car newCar = new Car()
            {
                Name = newCarDto.Name,
                Brand = newCarDto.Brand,
                Category = newCarDto.Category,
                Color = newCarDto.Color,
                Acessories = newCarDto.Acessories
            };

            await _garageRepository.CreateCar(newCar);
            bool success = await _garageRepository.CommitAsync();

            if (!success)
                throw new Exception("Oops, something went wrong.");

            return newCar;
        }

        public async Task<Car> Get(Guid id)
            => await _garageRepository.GetCarById(id);

        public async Task RequestCar(RentRequestDto rentRequest)
        {
            Car car = await _garageRepository.GetCarById(rentRequest.CarId);

            if (car is null)
                throw new Exception("Car doesn't exists.");

            DateOnly rentStartRequested = DateOnly.FromDateTime(rentRequest.RentStart);

            if (car.RentalStatus.IsRented && rentStartRequested <= car.RentalStatus.ReturnsIn)
                throw new Exception("This car is already rented for this period.");

            await _bus.PubSub.PublishAsync(new RentRequestIntegrationMessage()
            {
                CustomerId = rentRequest.CustomerId,
                CarId = rentRequest.CarId,
                StartRentDate = rentStartRequested,
                EndRentDate = DateOnly.FromDateTime(rentRequest.RentEnd)
            });
        }
    }
}