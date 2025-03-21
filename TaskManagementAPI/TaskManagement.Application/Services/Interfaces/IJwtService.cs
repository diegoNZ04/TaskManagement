using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}