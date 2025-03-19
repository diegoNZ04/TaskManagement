using FluentValidation;
using TaskManagement.Application.Dtos.Requests;

namespace TaskManagement.Application.Validators.TaskValidators;

public class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskValidator()
    {
        RuleFor(task => task.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(255).WithMessage("Title must not exceed 255 characters");

        RuleFor(task => task.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(255).WithMessage("Description must not exceed 255 characters");

        RuleFor(task => task.Priority)
            .NotEmpty().WithMessage("Priority is required")
            .IsInEnum().WithMessage("Priority is not valid");

        RuleFor(task => task.UserId)
            .NotEmpty().WithMessage("UserId is required")
            .GreaterThan(0).WithMessage("UserId must be greater than 0");
    }
}