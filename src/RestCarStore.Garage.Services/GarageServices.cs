using EasyNetQ;
using RentCartStore.Core.Messaging.IntegrationMessages;
using RestCarStore.Garage.Domain;
using RestCarStore.Garage.Services.Dtos;

namespace RestCarStore.Garage.Services
{
    public interface IGarageServices
    {
        public Task<Car> Create(CarDto newCar);
        public Task<Car> Get(Guid id);
    }
    public class GarageServices : IGarageServices
    {
        private readonly IBus _bus;

        public GarageServices(IBus bus)
        {
            _bus = bus;
        }

        public Task<Car> Create(CarDto newCar)
        {
            throw new NotImplementedException();
        }

        public async Task<Car> Get(Guid id)
        {
            await _bus.PubSub.PublishAsync<RentRequestMessage>(new RentRequestMessage() { Id = id });

            return null;
        }
    }
}