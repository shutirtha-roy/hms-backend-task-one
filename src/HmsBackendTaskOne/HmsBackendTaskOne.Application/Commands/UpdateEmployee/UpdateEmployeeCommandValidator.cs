using FluentValidation;

namespace HmsBackendTaskOne.Application.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(u => u.Employee.Name).NotEmpty().WithMessage("Name must not be empty");
            RuleFor(u => u.Employee.Email).EmailAddress();
            RuleFor(u => u.Employee.Designation).NotEmpty().WithMessage("Designation must not be empty");
            RuleFor(u => u.Employee.Phone).NotEmpty().WithMessage("Phone must not be empty");
            RuleFor(u => u.Employee.Salary).NotEmpty().WithMessage("Salary must not be empty");
            RuleFor(u => u.Employee.Department).NotEmpty().WithMessage("Department must not be empty");
        }
    }
}