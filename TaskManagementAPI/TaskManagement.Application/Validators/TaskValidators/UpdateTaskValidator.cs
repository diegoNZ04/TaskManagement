using FluentValidation;
using TaskManagement.Application.Dtos.Requests.UserTasksRequests;

namespace TaskManagement.Application.Validators.TaskValidators;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskRequest>
{
    public UpdateTaskValidator()
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
    }
}