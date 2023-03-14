using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Commands.AddEmployee
{
    public record AddEmployeeCommand(Employee Employee) : IRequest<Employee>;
}