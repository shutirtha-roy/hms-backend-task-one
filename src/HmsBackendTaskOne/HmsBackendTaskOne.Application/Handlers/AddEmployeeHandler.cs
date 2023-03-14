using HmsBackendTaskOne.Application.Commands;
using HmsBackendTaskOne.Application.Queries;
using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using MediatR;

namespace HmsBackendTaskOne.Application.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public AddEmployeeHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            _applicationUnitOfWork.Employees.Add(request.Employee);
            _applicationUnitOfWork.Save();

            return request.Employee;
        }
    }
}