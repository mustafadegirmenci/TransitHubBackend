using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class RequestRepository : Repository<Request>, IRequestRepository
{
    public RequestRepository(ApplicationDbContext context) : base(context)
    {
    }
}