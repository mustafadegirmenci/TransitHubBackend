using MediatR;

namespace Application.Features.Customer.Authorization.Login;

public class LoginCustomerRequest : IRequest<LoginCustomerResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}