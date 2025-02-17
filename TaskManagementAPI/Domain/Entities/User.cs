using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Entities
{
    public class User
    {
        // Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Username
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        // Email
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        // PasswordHash
        [Required]
        [MaxLength(12), MinLength(8)]
        public string PasswordHash { get; set; } = string.Empty;
        public List<TaskItem>? Tasks { get; } = null!;

    }
}