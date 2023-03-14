using HmsBackendTaskOne.Application.Commands;
using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using MediatR;

namespace HmsBackendTaskOne.Application.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public DeleteEmployeeHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            _applicationUnitOfWork.Employees.Remove(request.Id);
            _applicationUnitOfWork.Save();

            return Unit.Value;
        }
    }
}