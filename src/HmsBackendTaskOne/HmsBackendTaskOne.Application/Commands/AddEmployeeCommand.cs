using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Commands
{
    public record AddEmployeeCommand(Employee Employee) : IRequest<Employee>;
}