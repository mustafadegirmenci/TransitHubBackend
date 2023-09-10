using Domain.Enums;

namespace Application.Services;

public interface ITokenService
{
    public string GenerateToken(string seed, UserRole userRole);
}