using Application.Repositories.Entity;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Entity;

public class ResponseRepository : Repository<Response>, IResponseRepository
{
    public ResponseRepository(ApplicationDbContext context) : base(context)
    {
    }
}