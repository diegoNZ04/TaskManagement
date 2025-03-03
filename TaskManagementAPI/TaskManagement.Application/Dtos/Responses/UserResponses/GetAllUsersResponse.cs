namespace TaskManagement.Application.Dtos.Responses.UserResponses;

public class GetAllUsersResponse
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}