using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Dtos.Responses.UserTasksResponses;

public class GetAllTasksResponse
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
}