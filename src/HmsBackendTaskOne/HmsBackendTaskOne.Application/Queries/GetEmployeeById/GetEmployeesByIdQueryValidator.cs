using FluentValidation;
using HmsBackendTaskOne.Application.Commands.AddEmployee;
using HmsBackendTaskOne.Domain.Entities;
using MediatR;

namespace HmsBackendTaskOne.Application.Queries.GetEmployeeById
{
    public class GetEmployeesByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeesByIdQueryValidator()
        {
            RuleFor(u => u.Id).NotEmpty().NotNull().WithMessage("Id must not be empty");
        }
    }
}