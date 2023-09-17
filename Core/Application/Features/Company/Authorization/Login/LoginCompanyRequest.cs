using MediatR;

namespace Application.Features.Company.Authorization.Login;

public class LoginCompanyRequest : IRequest<LoginCompanyResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}