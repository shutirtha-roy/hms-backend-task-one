using FluentValidation;

namespace HmsBackendTaskOne.Application.Commands.AddEmployee
{
    public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidator()
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