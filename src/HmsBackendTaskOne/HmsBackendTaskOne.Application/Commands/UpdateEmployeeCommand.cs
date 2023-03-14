using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Commands
{
    public record UpdateEmployeeCommand(Employee Employee) : IRequest<Employee>;
}