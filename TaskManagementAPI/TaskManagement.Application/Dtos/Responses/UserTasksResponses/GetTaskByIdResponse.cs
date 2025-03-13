using TaskManagement.Application.Dtos.Responses.SubTasksResponses;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Dtos.Responses.UserTasksResponses;

public class GetTaskByIdResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public int UserId { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ICollection<CreateSubTaskResponse>? SubTasks { get; set; } = [];
}