using TaskManagement.Application.Dtos.Responses.UserResponses;

namespace TaskManagement.Application.Services.Interfaces;

public interface IUserService
{
    Task<CreateUserResponse> CreateUserAsync(string username, string password, string email);
    Task DeleteUserAsync(int userId);
    Task<IEnumerable<GetAllUsersResponse>> GetAllUsersAsync();
    Task<GetUserByIdResponse> GetUserByIdAsync(int userId);
}