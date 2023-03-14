using HmsBackendTaskOne.Application.Queries.GetEmployeeById;
using HmsBackendTaskOne.Application.Services;
using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using MediatR;

namespace HmsBackendTaskOne.Application.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeService _employeeService;

        public GetEmployeeByIdHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetEmployeeById(request.Id);
            return employee;
        }
    }
}