namespace TaskManagement.Application.Dtos.Responses.SubTasksResponses;

public class CreateSubTaskResponse
{
    public string Description { get; set; } = string.Empty;
    public int UserTaskId { get; set; }
}