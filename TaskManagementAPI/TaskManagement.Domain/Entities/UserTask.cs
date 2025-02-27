using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities;

public class UserTask
{
    // Id
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    // Title
    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;
    // Description
    [Required]
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;
    // Priority
    [Required]
    public TaskPriority Priority { get; set; }
    public ICollection<SubTask>? SubTasks { get; set; } = [];
    // FK UserId
    [Required]
    public int UserId { get; set; }
    // Navigation Property
    public User User { get; set; } = null!;
    // IsCompleted
    public bool IsCompleted { get; set; } = false;
    // CompletedAt 
    [DataType(DataType.DateTime)]
    public DateTime? CompletedAt { get; set; } = null;
    // DueDate
    [DataType(DataType.DateTime)]
    public DateTime? DueDate { get; set; } = null;
}