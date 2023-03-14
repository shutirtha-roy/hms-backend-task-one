using HmsBackendTaskOne.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsBackendTaskOne.Application.Queries
{
    public record GetEmployeeByIdQuery(Guid Id) : IRequest<Employee>;
}