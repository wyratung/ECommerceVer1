using Basket.API.Repositories;
using Common.Contracts.Interfaces;
using Common.Infas.Repositories;
using Common.Shared.Configurations;
using Common.Infas.Extensions;
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
    }
}
