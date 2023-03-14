using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Queries.GetEmployeeById
{
    public record GetEmployeeByIdQuery(Guid Id) : IRequest<Employee>;
}