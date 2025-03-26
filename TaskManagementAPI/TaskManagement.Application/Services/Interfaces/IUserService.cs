using TaskManagement.Application.Dtos.Responses.UserResponses;

namespace TaskManagement.Application.Services.Interfaces;

public interface IUserService
{
    Task<CreateUserResponse> CreateUserAsync(string username, string password, string email);
    Task DeleteUserAsync(int userId);
    Task<(IEnumerable<GetAllUsersResponse> Users, int TotalCount)> GetAllUsersAsync(int page, int pageSize);
    Task<GetUserByIdResponse> GetUserByIdAsync(int userId);
}