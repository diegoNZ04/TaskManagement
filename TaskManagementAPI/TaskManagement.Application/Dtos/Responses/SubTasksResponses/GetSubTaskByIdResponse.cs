namespace TaskManagement.Application.Dtos.Responses.SubTasksResponses;

public class GetSubTaskByIdResponse
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int UserTaskId { get; set; }
    public bool IsCompleted { get; set; }
}