using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Dtos.Requests.UserTasksRequests
{
    public class UpdateTaskRequest
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public TaskPriority Priority { get; set; }
    }
}