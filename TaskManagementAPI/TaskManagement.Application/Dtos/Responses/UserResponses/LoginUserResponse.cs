using TaskManagement.Application.Dtos.Requests.UserResquests;

namespace TaskManagement.Application.Dtos.Responses.UserResponses;

public class LoginUserResponse
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}