using FluentValidation;
using TaskManagement.Application.Dtos.Requests.SubTasksRequests;

namespace TaskManagement.Application.Validators.SubTaskValidators;

public class CreateSubTaskValidator : AbstractValidator<CreateSubTaskRequest>
{
    public CreateSubTaskValidator()
    {
        RuleFor(subTask => subTask.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(255).WithMessage("Description must not exceed 255 characters");

        RuleFor(subTask => subTask.UserTaskId)
            .NotEmpty().WithMessage("UserTaskId is required")
            .GreaterThan(0).WithMessage("UserTaskId must be greater than 0");
    }
}