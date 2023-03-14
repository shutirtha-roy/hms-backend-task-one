using HmsBackendTaskOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HmsBackendTaskOne.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }
    }
}