using Application.Services;
using MediatR;

namespace Application.Features.Authorization.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly IAuthService _authService;

    public RegisterHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var response = await _authService.RegisterAsync(
            request.Username,
            request.Password,
            request.Name,
            request.Surname,
            request.Role
        );

        return response;
    }
}
