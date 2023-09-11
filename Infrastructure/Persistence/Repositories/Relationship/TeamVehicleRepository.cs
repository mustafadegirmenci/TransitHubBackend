using Application.Repositories.Relationship;
using Domain.Relationships;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Relationship;

public class TeamVehicleRepository : Repository<TeamVehicle>, ITeamVehicleRepository
{
    public TeamVehicleRepository(ApplicationDbContext context) : base(context)
    {
    }
}