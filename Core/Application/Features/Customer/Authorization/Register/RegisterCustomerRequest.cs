using MediatR;

namespace Application.Features.Customer.Authorization.Register;

public class RegisterCustomerRequest : IRequest<RegisterCustomerResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
