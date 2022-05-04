using RentCarStore.Financial.Domain;
using RentCarStore.Financial.Services;

namespace RentCarStore.Financial.Endpoints
{
    public class FinancialEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/financial/rents/{customerId}", GetAllCustomerRents);
        }

        private static async Task<List<RentRecord>> GetAllCustomerRents(IFinancialServices financialServices, Guid customerId)
            => await financialServices.GetByCustomerId(customerId);
    }
}
