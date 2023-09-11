using Application.Features.Authorization.Login;
using Application.Features.Authorization.Register;
using Domain.Enums;

namespace Application.Services;

public interface IAuthService
{
    public Task<RegisterResponse> RegisterAsync(string username, string password, string name, string surname,
        UserRole role);
    
    public Task<LoginResponse> LoginAsync(string username, string password);
}