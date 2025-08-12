using Microsoft.Extensions.Options;

namespace Inventory.API.Extentions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var settings = services.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            ArgumentNullException.ThrowIfNullOrEmpty(settings.ConnectionString);

            var mongoClient = services.GetRequiredService<IMongoClient>();
            new InventoryDbSeed()
                .SeedDataAsync(mongoClient, settings)
                .Wait();

            return host;
        }
    }
}
