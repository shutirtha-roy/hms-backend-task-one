using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Queries
{
    public record GetEmployeesQuery : IRequest<IList<Employee>>;
}