using AutoMapper;
using HmsBackendTaskOne.Application.Queries.GetAllEmployees;
using HmsBackendTaskOne.Application.Services;
using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using MediatR;

namespace HmsBackendTaskOne.Application.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeesQuery, IList<Employee>>
    {
        private readonly IEmployeeService _employeeService;

        public GetEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IList<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetAllEmployees();
            return employee;
        } 
    }
}