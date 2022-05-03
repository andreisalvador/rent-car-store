using EasyNetQ;
using RentCartStore.Core.Messaging.IntegrationMessages;

namespace RentCarStore.Financial.Services
{
    public class RentRequestService : BackgroundService
    {
        private readonly IBus _bus;
        private readonly ILogger<RentRequestService> _logger;

        public RentRequestService(IBus bus, ILogger<RentRequestService> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting rent request processing.");

            _bus.PubSub.SubscribeAsync<RentRequestMessage>(nameof(RentRequestMessage), ProcessRentRequest);

            return Task.CompletedTask;
        }

        private void ProcessRentRequest(RentRequestMessage message)
        {
            _logger.LogInformation($"Starting rent request processing with id {message.Id}");
        }
    }
}
