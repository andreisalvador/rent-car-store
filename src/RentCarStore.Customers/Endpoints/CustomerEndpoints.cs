using Microsoft.AspNetCore.Mvc;
using RentCarStore.Customers.Domain;
using RentCarStore.Customers.Services;
using RentCarStore.Customers.Services.Dtos;

namespace RentCarStore.Customers.Endpoints
{
    public class CustomerEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapPost("/create-customer", Create);
            app.MapGet("/get-customer/{id}", Get);
        }

        public static Task<Customer> Create(ICustomersServices customersServices, CustomerDto newCustomer) 
            => customersServices.Create(newCustomer);

        public static Task<Customer> Get(ICustomersServices customersServices, Guid id)
            => customersServices.Get(id);
    }
}
