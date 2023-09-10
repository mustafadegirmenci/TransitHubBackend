using Application.Repositories;
using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Features.Authorization.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public RegisterHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var newUser = await _authService.RegisterAsync(request.Username, request.Password, request.Name, request.Surname);
        
        return new RegisterResponse
        {
            UserId = newUser?.Id ?? -1,
            Message = "Registration successful.",
        };
    }
}
