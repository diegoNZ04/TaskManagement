using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem
    {
        // Id
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; } = string.Empty;
        public List<SubTask>? SubTasks { get; } = null!;
    }
}