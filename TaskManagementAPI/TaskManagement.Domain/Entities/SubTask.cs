using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Entities;

public class SubTask
{
    // Id
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    // Description
    [Required]
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;
    // FK UserTaskId
    [Required]
    public int UserTaskId { get; set; }
    // Navigation Property
    public UserTask UserTask { get; set; } = null!;
    // IsCompleted
    public bool IsCompleted { get; set; } = false;
    // CompletedAt 
    [DataType(DataType.DateTime)]
    public DateTime? CompletedAt { get; set; } = null;
    // DueDate
    [DataType(DataType.DateTime)]
    public DateTime? DueDate { get; set; } = null;
}