using EasyNetQ;
using RentCartStore.Core.Messaging.IntegrationMessages;
using RestCarStore.Garage.Services;

namespace RentCarStore.Garage.BackgroundServices
{
    public class GarageRentRequestService : BackgroundService
    {
        private readonly IBus _bus;
        private readonly ILogger<GarageRentRequestService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public GarageRentRequestService(IBus bus, ILogger<GarageRentRequestService> logger, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting garage rent request processing.");

            _bus.PubSub.SubscribeAsync<RentRequestApprovedIntegrationMessage>(nameof(RentRequestApprovedIntegrationMessage), ProcessApprovedRentRequest);

            return Task.CompletedTask;
        }

        private async Task ProcessApprovedRentRequest(RentRequestApprovedIntegrationMessage message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var garageServices = scope.ServiceProvider.GetRequiredService<IGarageServices>();
                garageServices.ApproveRent(new RestCarStore.Garage.Services.Dtos.ApprovedRentRequestDto()
                {
                    CarId = message.CarId,
                    CustomerId = message.CustomerId,
                    RentEnd = message.EndRentDate,
                    RentStart = message.StartRentDate,
                    RentCode = message.RentCode
                });
            }
        }
    }
}
