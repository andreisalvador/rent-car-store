using Microsoft.EntityFrameworkCore;
using RentCarStore.Financial.BackgroundServices;
using RentCarStore.Financial.Data;
using RentCarStore.Financial.Data.Repositories;
using RentCarStore.Financial.Services;
using RentCartStore.Core.Messaging.Extensions;

namespace RentCarStore.Financial.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            AddData(services);
            AddServices(services);
            AddBackgroundServices(services);

            return services.AddMessaging("host=localhost");
        }

        private static void AddBackgroundServices(IServiceCollection services)
        {
            services.AddHostedService<RentRequestService>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IFinancialServices, FinancialServices>();
        }

        private static void AddData(IServiceCollection services)
        {
            services.AddDbContext<FinancialContext>(o => o.UseNpgsql("User ID = andrei.salvador;Password=pgpass;Server=localhost;Port=5433;Database=RentCarStoreDb;Integrated Security=true;Pooling=true"));
            services.AddScoped<FinancialContext>();
            services.AddScoped<IFinancialRepository, FinancialRepository>();
        }
    }
}
