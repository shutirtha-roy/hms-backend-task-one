using HmsBackendTaskOne.Domain.IRepositories;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace HmsBackendTaskOne.Application.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IEmployeeRepository Employees { get; private set; }
        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            IEmployeeRepository employeeRepository) : base((DbContext)dbContext)
        {
            Employees = employeeRepository;
        }
    }
}