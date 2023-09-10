namespace Application.Services;

public interface IHashingService
{
    public string Hash(string initialValue);
}