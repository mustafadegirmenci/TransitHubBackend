namespace Application.Features.Authorization.Register;

public class RegisterResponse
{
    public bool RegistrationSucceeded { get; set; }
    public int? UserId { get; set; }
    public string Message { get; set; }
}
