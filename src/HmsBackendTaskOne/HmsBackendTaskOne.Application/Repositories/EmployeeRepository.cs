using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HmsBackendTaskOne.Application.Repositories
{
    public class EmployeeRepository : Repository<Employee, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
    }
}