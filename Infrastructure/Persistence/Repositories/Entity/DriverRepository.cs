using Application.Repositories.Entity;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Entity;

public class DriverRepository : Repository<Driver>, IDriverRepository
{
    public DriverRepository(ApplicationDbContext context) : base(context)
    {
    }
}