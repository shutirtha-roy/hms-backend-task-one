using Autofac;
using AutoMapper;
using HmsBackendTaskOne.Domain.Entities;

namespace HmsBackendTaskOne.Application.DTOs
{
    public class EmployeeUpdateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public long Phone { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }

        private ILifetimeScope _scope;
        private IMapper _mapper;

        public async Task ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _mapper = _scope.Resolve<IMapper>();
        }

        public async Task<Employee> GetEmployeeUpdateObj()
        {
            return _mapper.Map<Employee>(this);
        }
    }
}
