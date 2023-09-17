using MediatR;

namespace Application.Features.Company.Authorization.Register;

public class RegisterCompanyRequest : IRequest<RegisterCompanyResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string FoundingDate { get; set; }
}
