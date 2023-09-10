namespace Application.Services;

public interface ITokenService
{
    public string GenerateToken(string seed);
}