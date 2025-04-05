using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Dtos.Requests.UserResquests;

public class LoginUserRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}