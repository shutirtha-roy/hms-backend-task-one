using AutoMapper;
using HmsBackendTaskOne.Domain.Entities;

namespace HmsBackendTaskOne.Application.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Employee, Employee>();
        }
    }
}