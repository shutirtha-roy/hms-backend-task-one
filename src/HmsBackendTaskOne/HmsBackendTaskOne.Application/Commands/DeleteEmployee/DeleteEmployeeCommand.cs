using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Commands.DeleteEmployee
{
    public record DeleteEmployeeCommand(Guid Id) : IRequest;
}