using Domain.Entities;

namespace Application.Services;

public interface IAuthService
{
    public Task<User?> RegisterAsync(string username, string password, string name, string surname);
}