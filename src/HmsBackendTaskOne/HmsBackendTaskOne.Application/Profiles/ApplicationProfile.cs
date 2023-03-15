using AutoMapper;
using HmsBackendTaskOne.Application.DTOs;
using HmsBackendTaskOne.Domain.Entities;

namespace HmsBackendTaskOne.Application.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Employee, Employee>();

            CreateMap<Employee, EmployeeCreateDTO>()
                .ReverseMap();

            CreateMap<Employee, EmployeeUpdateDTO>()
                .ReverseMap();
        }
    }
}