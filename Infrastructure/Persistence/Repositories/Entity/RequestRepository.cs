using Application.Repositories.Entity;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Entity;

public class RequestRepository : Repository<Request>, IRequestRepository
{
    public RequestRepository(ApplicationDbContext context) : base(context)
    {
    }
}