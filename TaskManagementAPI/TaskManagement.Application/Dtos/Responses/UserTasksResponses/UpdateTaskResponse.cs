using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Dtos.Responses.UserTasksResponses;

public class UpdateTaskResponse
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
}