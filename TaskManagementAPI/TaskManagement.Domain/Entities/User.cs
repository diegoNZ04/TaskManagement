using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Entities;

public class User
{
    // Id
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    // Username
    [Required]
    [MaxLength(255)]
    public string Username { get; set; } = string.Empty;
    // Email
    [Required]
    [MaxLength(255)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    // PasswordHash
    [Required]
    [MaxLength(255), MinLength(8)]
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; } = string.Empty;
    // Tasks
    public ICollection<UserTask>? Tasks { get; set; } = [];
}