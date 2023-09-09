using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class ChatRepository : Repository<Chat>, IChatRepository
{
    public ChatRepository(ApplicationDbContext context) : base(context)
    {
    }
}