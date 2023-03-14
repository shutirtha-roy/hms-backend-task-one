using HmsBackendTaskOne.Application.Commands.DeleteEmployee;
using HmsBackendTaskOne.Application.Services;
using MediatR;

namespace HmsBackendTaskOne.Application.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeService _employeeService;

        public DeleteEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeService.DeleteEmployee(request.Id);
        }
    }
}