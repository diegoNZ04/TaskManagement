using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
    string GeneratePasswordResetToken(User user);
    int? ValidatePasswordResetToken(string token);
}