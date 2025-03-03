using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Dtos.Requests.SubTasksRequests;

public class CreateSubTaskRequest
{
    [Required]
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public int UserTaskId { get; set; }
}