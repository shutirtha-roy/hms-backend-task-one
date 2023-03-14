using Autofac.Extensions.DependencyInjection;
using Autofac;
using HmsBackendTaskOne.API;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;
using HmsBackendTaskOne.Application;
using HmsBackendTaskOne.Application.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

try
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var assemblyName = Assembly.GetExecutingAssembly().FullName;

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => {
        containerBuilder.RegisterModule(new ApiModule());
        containerBuilder.RegisterModule(new ApplicationModule(connectionString,
            assemblyName));
    });

    // Add services to the container.
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString,
        m => m.MigrationsAssembly(assemblyName)));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    Log.Information("Web API is starting");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}