using Application.Services;

namespace Persistence.Services;

public class HashingService : IHashingService
{
    public string Hash(string initialValue)
    {
        return initialValue;
    }
}