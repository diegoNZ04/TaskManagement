namespace TaskManagement.Application.Dtos.Responses.SubTasksResponses;

public class CompleteSubTaskResponse
{
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
    public DateTime? CompletedAt { get; set; } = null;
}