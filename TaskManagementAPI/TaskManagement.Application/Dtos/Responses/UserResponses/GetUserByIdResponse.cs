using TaskManagement.Application.Dtos.Responses.UserTasksResponses;

namespace TaskManagement.Application.Dtos.Responses.UserResponses;

public class GetUserByIdResponse
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<CreateTaskResponse> TasksUser { get; set; } = [];
}