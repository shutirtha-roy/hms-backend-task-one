using HmsBackendTaskOne.Application.Commands;
using HmsBackendTaskOne.Application.Queries;
using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using MediatR;

namespace HmsBackendTaskOne.Application.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public UpdateEmployeeHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _applicationUnitOfWork.Employees.GetById(request.Employee.Id);
            employee.Name = request.Employee.Name;
            employee.Email = request.Employee.Email;
            employee.Designation = request.Employee.Designation;
            employee.Phone = request.Employee.Phone;
            employee.Salary = request.Employee.Salary;
            employee.Department = request.Employee.Department;

            _applicationUnitOfWork.Save();

            return request.Employee;
        }
    }
}