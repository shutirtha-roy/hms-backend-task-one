using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Commands
{
    public record DeleteEmployeeCommand(Guid Id) : IRequest<Unit>;
}