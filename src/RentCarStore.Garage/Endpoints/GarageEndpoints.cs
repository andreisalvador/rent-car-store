using RestCarStore.Garage.Domain;
using RestCarStore.Garage.Services;
using RestCarStore.Garage.Services.Dtos;

namespace RentCarStore.Garage.Endpoints
{
    public class GarageEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapPost("/garage/car", Create);
            app.MapPost("/garage/request-car", RequestCar);
            app.MapGet("/garage/car/{id}", Get);
        }

        private static async Task RequestCar(IGarageServices garageService, RentRequestDto rentRequest)
            => await garageService.RequestCar(rentRequest);

        public static async Task<Car> Create(IGarageServices garageService, CarDto newCar)
            => await garageService.Create(newCar);

        public static async Task<Car> Get(IGarageServices garageService, Guid id)
            => await garageService.Get(id);
    }
}
