using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Dtos.Requests.SubTasksRequests;

public class CreateSubTaskRequest
{
    public string Description { get; set; } = string.Empty;
    public int UserTaskId { get; set; }
}