using Autofac;
using HmsBackendTaskOne.Application.Handlers;
using HmsBackendTaskOne.Application.Queries.GetAllEmployees;
using HmsBackendTaskOne.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace HmsBackendTaskOne.API
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Services.AddScoped<IRequestHandler<GetEmployeesQuery, IList<Employee>>, GetEmployeeHandler>();
            

            base.Load(builder);
        }
    }
}
