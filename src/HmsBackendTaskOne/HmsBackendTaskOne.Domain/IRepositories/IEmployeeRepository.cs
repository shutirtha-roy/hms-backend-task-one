using HmsBackendTaskOne.Domain.Entities;

namespace HmsBackendTaskOne.Domain.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
    }
}