using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;

namespace RentCartStore.Core.Messaging.Extensions
{
    public static class MessagingExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, string connection)
            => services.AddSingleton(RabbitHutch.CreateBus(connection));
    }
}
