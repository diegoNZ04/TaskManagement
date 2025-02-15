using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Entities
{
    public class SubTask
    {
        // Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Name
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
