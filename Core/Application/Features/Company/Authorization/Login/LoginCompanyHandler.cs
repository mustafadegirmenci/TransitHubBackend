using Application.Services;
using MediatR;

namespace Application.Features.Company.Authorization.Login;

public class LoginCompanyHandler : IRequestHandler<LoginCompanyRequest, LoginCompanyResponse>
{
    private readonly IAuthService _authService;

    public LoginCompanyHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCompanyResponse> Handle(LoginCompanyRequest request, CancellationToken cancellationToken)
    {
        return await _authService.LoginCompanyAsync(request.Email, request.Password);
    }
}
