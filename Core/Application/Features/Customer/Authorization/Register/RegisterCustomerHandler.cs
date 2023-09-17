using Application.Services;
using MediatR;

namespace Application.Features.Customer.Authorization.Register;

public class RegisterCustomerHandler : IRequestHandler<RegisterCustomerRequest, RegisterCustomerResponse>
{
    private readonly IAuthService _authService;

    public RegisterCustomerHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RegisterCustomerResponse> Handle(RegisterCustomerRequest request, CancellationToken cancellationToken)
    {
        var response = await _authService.RegisterCustomerAsync(
            request.Email,
            request.Password,
            request.Name,
            request.Surname
        );

        return response;
    }
}
