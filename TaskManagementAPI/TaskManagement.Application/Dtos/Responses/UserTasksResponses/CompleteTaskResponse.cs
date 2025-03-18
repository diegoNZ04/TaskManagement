namespace TaskManagement.Application.Dtos.Responses.UserTasksResponses;

public class CompleteTaskResponse
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
}