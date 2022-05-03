using RentCarStore.Customers.Domain;
using RentCarStore.Customers.Services.Dtos;

namespace RentCarStore.Customers.Services
{
    public interface ICustomersServices
    {
        Task<Customer> Create(CustomerDto newCustomer);
        Task<Customer> Get(Guid id);
    }

    public class CustomerServices : ICustomersServices
    {
        public Task<Customer> Create(CustomerDto newCustomer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}