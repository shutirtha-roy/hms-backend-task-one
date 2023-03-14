using AutoMapper;
using Azure.Core;
using HmsBackendTaskOne.Domain.Entities;
using HmsBackendTaskOne.Domain.IUnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsBackendTaskOne.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            _applicationUnitOfWork.Employees.Add(employee);
            _applicationUnitOfWork.Save();

            return employee;
        }

        public async Task DeleteEmployee(Guid id)
        {
            _applicationUnitOfWork.Employees.Remove(id);
            _applicationUnitOfWork.Save();
        }

        public async Task<IList<Employee>> GetAllEmployees()
        {
            var employees = _applicationUnitOfWork.Employees.GetAll();

            return employees;
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            var employee = _applicationUnitOfWork.Employees.GetById(id);

            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee newEmployee)
        {
            var employee = _applicationUnitOfWork.Employees.GetById(newEmployee.Id);
            employee = _mapper.Map(newEmployee, employee);

            _applicationUnitOfWork.Save();

            return employee;
        }
    }
}
