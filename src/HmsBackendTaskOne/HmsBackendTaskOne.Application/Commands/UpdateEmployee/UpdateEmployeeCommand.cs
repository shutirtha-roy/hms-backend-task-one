using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Commands.UpdateEmployee
{
    public record UpdateEmployeeCommand(Employee Employee) : IRequest<Employee>;
}