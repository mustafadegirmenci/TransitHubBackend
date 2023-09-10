using Application.Repositories;
using Application.Services;
using Domain.Entities;

namespace Persistence.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IHashingService _hashingService;

    public AuthService(IUserRepository userRepository, IHashingService hashingService)
    {
        _userRepository = userRepository;
        _hashingService = hashingService;
    }

    public async Task<User?> RegisterAsync(string username, string password, string name, string surname)
    {
        if (await _userRepository.GetUserByUsernameAsync(username) != null)
        {
            throw new ApplicationException("Username is already taken.");
        }

        var hashedPassword = _hashingService.Hash(password);

        var user = new User
        {
            Username = username,
            PasswordHash = hashedPassword,
            Name = name,
            Surname = surname,
            DateCreated = DateTimeOffset.Now
        };

        await _userRepository.AddAsync(user);

        return user;
    }
}