namespace Application.Features.Authorization.Login;

public class LoginResponse
{
    public bool LoginSucceeded { get; set; }
    public string? Token { get; set; }
    public string Message { get; set; }
}