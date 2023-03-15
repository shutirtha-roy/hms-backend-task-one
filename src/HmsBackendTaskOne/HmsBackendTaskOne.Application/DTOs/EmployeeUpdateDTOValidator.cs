using FluentValidation;
using HmsBackendTaskOne.Domain.Entities;

namespace HmsBackendTaskOne.Application.DTOs
{
    public class EmployeeUpdateDTOValidator : AbstractValidator<EmployeeUpdateDTO>
    {
        public EmployeeUpdateDTOValidator()
        {
            RuleFor(u => u.Id).NotNull().NotEmpty();
            RuleFor(u => u.Name).NotEmpty().WithMessage("Name must not be empty");
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Designation).NotEmpty().WithMessage("Designation must not be empty");
            RuleFor(u => u.Phone).NotEmpty().WithMessage("Phone must not be empty");
            RuleFor(u => u.Salary).NotEmpty().WithMessage("Salary must not be empty");
            RuleFor(u => u.Department).NotEmpty().WithMessage("Department must not be empty");
        }
    }
}