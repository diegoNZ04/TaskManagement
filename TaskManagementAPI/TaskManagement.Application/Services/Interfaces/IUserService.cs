using TaskManagement.Application.Dtos.Requests.UserResquests;
using TaskManagement.Application.Dtos.Responses.UserResponses;

namespace TaskManagement.Application.Services.Interfaces;

public interface IUserService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
    Task DeleteUserAsync(int userId);
    Task<(IEnumerable<GetAllUsersResponse> Users, int TotalCount)> GetAllUsersAsync(int page, int pageSize);
    Task<GetUserByIdResponse> GetUserByIdAsync(int userId);
}