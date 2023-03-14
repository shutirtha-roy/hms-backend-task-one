using HmsBackendTaskOne.Domain.IRepositories;

namespace HmsBackendTaskOne.Domain.IUnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
    }
}