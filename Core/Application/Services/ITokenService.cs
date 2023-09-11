using Domain.Entities;

namespace Application.Services;

public interface ITokenService
{
    public string GenerateToken(User user);
}