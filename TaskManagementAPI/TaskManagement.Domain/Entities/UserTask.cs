using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities;

public class UserTask
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public ICollection<SubTask>? SubTasks { get; set; } = [];
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    public bool IsCompleted { get; set; } = false;
    [DataType(DataType.DateTime)]
    public DateTime? CompletedAt { get; set; } = null;
}