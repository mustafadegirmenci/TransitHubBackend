using Application.Repositories.Entity;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Entity;

public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(ApplicationDbContext context) : base(context)
    {
    }
}