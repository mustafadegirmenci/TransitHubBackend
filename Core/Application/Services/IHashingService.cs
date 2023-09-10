namespace Application.Services;

public interface IHashingService
{
    public string Hash(string initialValue);
    public bool Verify(string hash, string value);
}