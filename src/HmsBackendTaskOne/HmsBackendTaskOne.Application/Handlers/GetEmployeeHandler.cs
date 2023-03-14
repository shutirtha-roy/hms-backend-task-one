﻿using AutoMapper;
using HmsBackendTaskOne.Application.Queries;
using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using MediatR;

namespace HmsBackendTaskOne.Application.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeesQuery, IList<Employee>>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public GetEmployeeHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<IList<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employee = _applicationUnitOfWork.Employees.GetAll();
            return employee;
        } 
    }
}