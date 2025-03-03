using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Entities;

public class SubTask
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int UserTaskId { get; set; }
    [ForeignKey("UserTaskId")]
    public UserTask UserTask { get; set; } = null!;
    // IsCompleted
    public bool IsCompleted { get; set; } = false;
    // CompletedAt 
    [DataType(DataType.DateTime)]
    public DateTime? CompletedAt { get; set; } = null;
}