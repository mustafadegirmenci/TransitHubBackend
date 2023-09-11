using Application.Repositories.Entity;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Entity;

public class ChatRepository : Repository<Chat>, IChatRepository
{
    public ChatRepository(ApplicationDbContext context) : base(context)
    {
    }
}