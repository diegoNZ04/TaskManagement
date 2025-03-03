using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Dtos.Requests.UserResquests;

public class CreateUserRequest
{
    [Required]
    [MaxLength(255)]
    public string Username { get; set; } = string.Empty;
    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MaxLength(255), MinLength(8)]
    public string Password { get; set; } = string.Empty;
}