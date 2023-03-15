using FluentValidation;

namespace HmsBackendTaskOne.Application.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(u => u.Id).NotEmpty().NotNull().WithMessage("Id must not be full or empty");
        }
    }
}