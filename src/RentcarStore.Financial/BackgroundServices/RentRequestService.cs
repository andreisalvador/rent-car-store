using EasyNetQ;
using RentCarStore.Financial.Services;
using RentCartStore.Core.Messaging.IntegrationMessages;

namespace RentCarStore.Financial.BackgroundServices
{
    public class RentRequestService : BackgroundService
    {
        private readonly IBus _bus;
        private readonly ILogger<RentRequestService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public RentRequestService(IBus bus, ILogger<RentRequestService> logger, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting rent request processing.");

            _bus.PubSub.SubscribeAsync<RentRequestIntegrationMessage>(nameof(RentRequestIntegrationMessage), ProcessRentRequest, cancellationToken: stoppingToken);

            _bus.PubSub.SubscribeAsync<ReturnCarIntegrationMessage>(nameof(ReturnCarIntegrationMessage), ProcessReturnCar, cancellationToken: stoppingToken);

            AnalyseRentRequests(stoppingToken);

            return Task.CompletedTask;
        }

        private async Task ProcessReturnCar(ReturnCarIntegrationMessage obj)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var financialService = scope.ServiceProvider.GetRequiredService<IFinancialServices>();
                await financialService.ProcessRentRequest(message);
            }
        }

        private async Task ProcessRentRequest(RentRequestIntegrationMessage message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var financialService = scope.ServiceProvider.GetRequiredService<IFinancialServices>();
                await financialService.ProcessRentRequest(message);
            }
        }

        private async Task AnalyseRentRequests(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var financialService = scope.ServiceProvider.GetRequiredService<IFinancialServices>();
                    await financialService.AnalyseRentRequests();
                }
            }
        }
    }
}
