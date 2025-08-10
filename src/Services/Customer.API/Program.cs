using Common.Contracts.Interfaces;
using Common.Infas.Repositories;
using Common.Logging;
using Customer.API;
using Customer.API.APIs;
using Customer.API.Persistence;
using Customer.API.Repositories;
using Customer.API.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

Log.Information("Stating Customer API");
try
{
    // Use common config Seri logger
    builder.Host.UseSerilog(SeriLogger.Configure);
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<CustomerContext>(opt =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
        opt.UseNpgsql(connectionString);
    });

    builder.Services.AddScoped<ICustomerRepository, CustomerRepository>()
        .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
        .AddScoped<ICustomerService, CustomerService>();

    builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()));

    var app = builder.Build();
    app.MapGet("/", () => "Welcome to customer API");
    app.MapCustomersAPI();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.SeedCustomerData()
        .Run();
}
catch (Exception ex)
{
    string exceptionType = ex.GetType().Name;
    if (exceptionType.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shutdown Customer API complete");
    Log.CloseAndFlush();
}