using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(opt =>
            {
                var builder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnectionString"));
                opt.UseSqlServer(builder.ConnectionString,
                    optionAction => optionAction.MigrationsAssembly(typeof(OrderContext).Assembly));
            });

            services.AddScoped<OderContextSeed>();
            return services;
        }

    }
}
