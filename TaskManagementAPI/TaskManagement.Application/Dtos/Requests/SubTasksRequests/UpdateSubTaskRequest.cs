using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Dtos.Requests.SubTasksRequests;

public class UpdateSubTaskRequest
{
    public string Description { get; set; } = string.Empty;
}