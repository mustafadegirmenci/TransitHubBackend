using Application.Repositories.Relationship;
using Domain.Relationships;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Relationship;

public class DriverVehicleRepository : Repository<DriverVehicle>, IDriverVehicleRepository
{
    public DriverVehicleRepository(ApplicationDbContext context) : base(context)
    {
    }
}