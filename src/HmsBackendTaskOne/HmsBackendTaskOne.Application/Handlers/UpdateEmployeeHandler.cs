using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _applicationUnitOfWork.Employees.GetById(request.Employee.Id);
            employee = _mapper.Map(request.Employee, employee);

            _applicationUnitOfWork.Save();

            return request.Employee;
        }
    }
}