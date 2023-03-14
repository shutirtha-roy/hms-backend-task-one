using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Queries.GetAllEmployees
{
    public record GetEmployeesQuery : IRequest<IList<Employee>>;
}