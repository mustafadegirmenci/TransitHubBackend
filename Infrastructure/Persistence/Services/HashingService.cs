using Application.Services;

namespace Persistence.Services;

public class HashingService : IHashingService
{
    public string Hash(string initialValue)
    {
        return initialValue;
    }

    public bool Verify(string hash, string value)
    {
        return Hash(value) == hash;
    }
}