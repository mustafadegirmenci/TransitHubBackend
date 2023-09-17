using Application.Services;
using MediatR;

namespace Application.Features.Company.Authorization.Register;

public class RegisterCompanyHandler : IRequestHandler<RegisterCompanyRequest, RegisterCompanyResponse>
{
    private readonly IAuthService _authService;

    public RegisterCompanyHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RegisterCompanyResponse> Handle(RegisterCompanyRequest request, CancellationToken cancellationToken)
    {
        var response = await _authService.RegisterCompanyAsync(
            request.Email,
            request.Password,
            request.Name,
            request.FoundingDate
        );

        return response;
    }
}
