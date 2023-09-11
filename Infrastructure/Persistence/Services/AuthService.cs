using Application.Features.Authorization.Login;
using Application.Features.Authorization.Register;
using Application.Repositories.Entity;
using Application.Services;
using Domain.Entities;
using Domain.Enums;

namespace Persistence.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IHashingService _hashingService;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository userRepository, IHashingService hashingService, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _hashingService = hashingService;
        _tokenService = tokenService;
    }

    public async Task<RegisterResponse> RegisterAsync(string username, string password, string name, string surname,
        UserRole role)
    {
        if (await _userRepository.GetUserByUsernameAsync(username) is not null)
        {
            return new RegisterResponse
            {
                RegistrationSucceeded = false,
                UserId = null,
                Message = "The username is already taken."
            };
        }

        var hashedPassword = _hashingService.Hash(password);

        var user = new User
        {
            Username = username,
            PasswordHash = hashedPassword,
            Name = name,
            Surname = surname,
            Role = role,
            RegistrationDate = DateTimeOffset.Now
        };
        
        await _userRepository.AddAsync(user);

        return new RegisterResponse
        {
            RegistrationSucceeded = true,
            UserId = user.Id,
            Message = "Registration successful."
        };
    }
    
    public async Task<LoginResponse> LoginAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);

        if (user is null)
        {
            return new LoginResponse
            {
                LoginSucceeded = false,
                Token = null,
                Message = "User not found."
            };
        }
            
        var isPasswordValid = _hashingService.Verify(user.PasswordHash, password);

        if (!isPasswordValid)
        {
            return new LoginResponse
            {
                LoginSucceeded = false,
                Token = null,
                Message = "Invalid credentials."
            };
        }

        return new LoginResponse
        {
            LoginSucceeded = true,
            Token = _tokenService.GenerateToken(user),
            Message = "Invalid credentials."
        };
    }
}