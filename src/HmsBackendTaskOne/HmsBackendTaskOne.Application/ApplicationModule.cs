using Autofac;
using HmsBackendTaskOne.Application.Commands.UpdateEmployee;
using HmsBackendTaskOne.Application.DbContexts;
using HmsBackendTaskOne.Application.Handlers;
using HmsBackendTaskOne.Application.Repositories;
using HmsBackendTaskOne.Application.Services;
using HmsBackendTaskOne.Application.UnitOfWorks;
using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IRepositories;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using MediatR;

namespace HmsBackendTaskOne.Application
{
    public class ApplicationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeService>()
                .As<IEmployeeService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>()
                .As<IEmployeeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>()
                .As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}