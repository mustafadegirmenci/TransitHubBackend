using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class ResponseRepository : Repository<Response>, IResponseRepository
{
    public ResponseRepository(ApplicationDbContext context) : base(context)
    {
    }
}