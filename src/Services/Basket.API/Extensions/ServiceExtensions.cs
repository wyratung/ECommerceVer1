using Basket.API.Repositories;
using Common.Contracts.Interfaces;
using Common.EvenBus.IntergationEvents.Interfaces;
using Common.Infas.Extensions;
using Common.Infas.Repositories;
using Common.Shared.Configurations;
using MassTransit;
namespace Basket.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructures(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBasketRepository, BasketRepository>()
                    .AddTransient<ISerializeService, SerializeService>();

            return services;
        }

        internal static IServiceCollection ConfigueRedis(this IServiceCollection services)
        {
            var cacheSettings = services.GetOptions<CacheSettings>(sectionName: CacheSettings.Position);
            ArgumentNullException.ThrowIfNullOrEmpty(cacheSettings.ConnectionString, nameof(cacheSettings));

            services.AddStackExchangeRedisCache(opt => opt.Configuration = cacheSettings.ConnectionString);
            return services;
        }
        internal static IServiceCollection ConfigureMassTransit(this IServiceCollection services)
        {
            var eventBusSettings = services.GetOptions<EventBusSettings>(EventBusSettings.Position);
            var mqConnection = new Uri(eventBusSettings.HostAddress);
            services.AddSingleton(KebabCaseEndpointNameFormatter.Instance);
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(mqConnection);
                });

                //Publish submit order message
                config.AddRequestClient<IBasketCheckoutEvent>();
            });

            return services;
        }
    }
}
