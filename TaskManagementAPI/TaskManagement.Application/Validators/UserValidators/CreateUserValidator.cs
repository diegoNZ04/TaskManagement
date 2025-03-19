using FluentValidation;
using TaskManagement.Application.Dtos.Requests.UserResquests;

namespace TaskManagement.Application.Validators.UserValidators;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Username)
        .NotEmpty().WithMessage("Username is required")
        .MaximumLength(255).WithMessage("Username must not exceed 255 characters");

        RuleFor(user => user.Email)
        .NotEmpty().WithMessage("Email is required")
        .MaximumLength(255).WithMessage("Email must not exceed 255 characters");

        RuleFor(user => user.Password)
       .NotEmpty().WithMessage("Password is required")
       .MaximumLength(255).WithMessage("Password must not exceed 255 characters")
       .MinimumLength(8).WithMessage("Password must be at least 8 characters");
    }
}