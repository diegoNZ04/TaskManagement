using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Dtos.Requests.SubTasksRequests;

public class UpdateSubTaskRequest
{
    [Required]
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;
}