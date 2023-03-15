using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using HmsBackendTaskOne.API;
using HmsBackendTaskOne.Application;
using HmsBackendTaskOne.Application.Commands.AddEmployee;
using HmsBackendTaskOne.Application.Commands.DeleteEmployee;
using HmsBackendTaskOne.Application.Commands.UpdateEmployee;
using HmsBackendTaskOne.Application.DbContexts;
using HmsBackendTaskOne.Application.DTOs;
using HmsBackendTaskOne.Application.Handlers;
using HmsBackendTaskOne.Application.Queries.GetAllEmployees;
using HmsBackendTaskOne.Application.Queries.GetEmployeeById;
using HmsBackendTaskOne.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;

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
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApiModule());
        containerBuilder.RegisterModule(new ApplicationModule(connectionString,
            assemblyName));
    });

    // Add services to the container.
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString,
        m => m.MigrationsAssembly(assemblyName)));

    //builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Program).Assembly));

    builder.Services.AddMediatR(configuration =>
    {
        configuration.Lifetime = ServiceLifetime.Scoped;
        configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    });

    builder.Services.AddScoped<IRequestHandler<GetEmployeesQuery, IList<Employee>>, GetEmployeeHandler>();
    builder.Services.AddScoped<IRequestHandler<GetEmployeeByIdQuery, Employee>, GetEmployeeByIdHandler>();
    builder.Services.AddScoped<IRequestHandler<AddEmployeeCommand, Employee>, AddEmployeeHandler>();
    builder.Services.AddScoped<IRequestHandler<UpdateEmployeeCommand, Employee>, UpdateEmployeeHandler>();
    builder.Services.AddScoped<IRequestHandler<DeleteEmployeeCommand>, DeleteEmployeeHandler>();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddControllers()
    .AddFluentValidation(c =>
    {
        c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

    builder.Services.AddTransient<IValidator<EmployeeCreateDTO>, EmployeeCreateDTOValidator>();
    builder.Services.AddTransient<IValidator<EmployeeUpdateDTO>, EmployeeUpdateDTOValidator>();
    builder.Services.AddTransient<IValidator<AddEmployeeCommand>, AddEmployeeCommandValidator>();
    builder.Services.AddTransient<IValidator<DeleteEmployeeCommand>, DeleteEmployeeCommandValidator>();
    builder.Services.AddTransient<IValidator<GetEmployeeByIdQuery>, GetEmployeesByIdQueryValidator>();

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