using HmsBackendTaskOne.Application.Queries;
using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using MediatR;

namespace HmsBackendTaskOne.Application.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public GetEmployeeByIdHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = _applicationUnitOfWork.Employees.GetById(request.Id);
            return employee;
        }
    }
}