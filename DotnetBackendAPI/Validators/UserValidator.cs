using DotnetBackendAPI.DTOs;
using FluentValidation;

namespace DotnetBackendAPI.Validators;

public class UserValidator : AbstractValidator<AddUserDto>
{
    public UserValidator()
    {
        RuleFor(dto => dto.Name)
    .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Surname)
            .NotEmpty().WithMessage("SurName cannot be empty");

        RuleFor(dto => dto.Number)
            .NotEmpty().WithMessage("Number cannot be empty");
    }
}
