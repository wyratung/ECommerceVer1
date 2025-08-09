﻿using Common.Contracts.Interfaces;
using Common.Infas.Repositories;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Product.API.Persistence;
using Product.API.Repositories;
using AutoMapper;
namespace Product.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddControllers();
            // Auto convert url to lowercase
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ConfigureProductDbContext(configuration);
            services.AddInfrastructureServices();

            //services.AddAutoMapper([typeof(MappingProfile)]);
            services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile())); // or use this way

            return services;
        }

        private static IServiceCollection ConfigureProductDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString")
                ?? throw new InvalidOperationException("Connection string isn't valid");

            // Use to parse connection string
            var builder = new MySqlConnectionStringBuilder(connectionString);

            services.AddDbContext<ProductContext>(option =>
            {
                option.UseMySql(builder.ConnectionString,
                    ServerVersion.AutoDetect(builder.ConnectionString),
                    e =>
                    {
                        // Specify the project containing the migration
                        e.MigrationsAssembly("Product.API");
                        // Ignore scheme for DBMS doesn't have "scheme" mechanism
                        e.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                    });
            });

            return services;
        }

        private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBaseAsync<,,>), typeof(RepositoryBaseAsync<,,>))
                    .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
                    .AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
