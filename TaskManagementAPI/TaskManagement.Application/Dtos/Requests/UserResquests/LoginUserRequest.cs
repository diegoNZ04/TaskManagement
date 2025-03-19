using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Dtos.Requests.UserResquests;

public class LoginUserRequest
{
    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MaxLength(255), MinLength(8)]
    public string Password { get; set; } = string.Empty;
}