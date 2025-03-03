using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; } = string.Empty;
    public ICollection<UserTask>? Tasks { get; set; } = [];
}

