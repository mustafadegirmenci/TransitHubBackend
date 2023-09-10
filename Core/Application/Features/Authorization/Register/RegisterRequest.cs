using Domain.Enums;
using MediatR;

namespace Application.Features.Authorization.Register;

public class RegisterRequest : IRequest<RegisterResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserRole Role { get; set; }
}
