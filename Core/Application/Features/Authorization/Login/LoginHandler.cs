using Application.Services;
using MediatR;

namespace Application.Features.Authorization.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IAuthService _authService;

    public LoginHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        return await _authService.LoginAsync(request.Username, request.Password);
    }
}
