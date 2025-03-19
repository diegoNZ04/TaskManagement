using FluentValidation;
using TaskManagement.Application.Dtos.Requests.SubTasksRequests;

namespace TaskManagement.Application.Validators.SubTaskValidators
{
    public class UpdateSubTaskValidator : AbstractValidator<UpdateSubTaskRequest>
    {
        public UpdateSubTaskValidator()
        {
            RuleFor(subTask => subTask.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(255).WithMessage("Description must not exceed 255 characters");
        }
    }
}