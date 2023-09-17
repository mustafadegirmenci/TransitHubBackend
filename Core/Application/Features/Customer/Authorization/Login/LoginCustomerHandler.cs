using Application.Services;
using MediatR;

namespace Application.Features.Customer.Authorization.Login;

public class LoginCustomerHandler : IRequestHandler<LoginCustomerRequest, LoginCustomerResponse>
{
    private readonly IAuthService _authService;

    public LoginCustomerHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCustomerResponse> Handle(LoginCustomerRequest request, CancellationToken cancellationToken)
    {
        return await _authService.LoginCustomerAsync(request.Email, request.Password);
    }
}
