﻿using Autofac;
using HmsBackendTaskOne.Application.DbContexts;

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

            base.Load(builder);
        }
    }
}