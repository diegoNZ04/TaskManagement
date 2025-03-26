using TaskManagement.Domain.Entities;

namespace TaskManagement.Infra.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<(IEnumerable<User> Users, int TotalCount)> GetAllUsersAsync(int page, int pageSize);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}