using Microsoft.EntityFrameworkCore;
using RentCarStore.Garage.BackgroundServices;
using RentCarStore.Garage.Data;
using RentCarStore.Garage.Data.Repositories;
using RentCartStore.Core.Messaging.Extensions;
using RestCarStore.Garage.Services;

namespace RentCarStore.Garage.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            AddData(services);
            AddServices(services);
            AddBackgroundServices(services);

            return services.AddMessaging("host=rent-car-store-rabbitmq"); ;
        }

        private static void AddBackgroundServices(IServiceCollection services)
        {
            services.AddHostedService<GarageRentRequestService>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IGarageServices, GarageServices>();
        }

        private static void AddData(IServiceCollection services)
        {
            services.AddDbContext<GarageContext>(o => o.UseNpgsql("User ID = andrei.salvador;Password=pgpass;Server=rent-car-store-postgresql;Port=5432;Database=RentCarStoreDb;Integrated Security=true;Pooling=true"));
            services.AddScoped<GarageContext>();
            services.AddScoped<IGarageRepository, GarageRepository>();
        }
    }
}
