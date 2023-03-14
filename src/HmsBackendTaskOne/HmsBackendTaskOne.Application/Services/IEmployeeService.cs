using HmsBackendTaskOne.Domain.Entities;

namespace HmsBackendTaskOne.Application.Services
{
    public interface IEmployeeService
    {
        Task<IList<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(Guid id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployee(Guid id);
    }
}