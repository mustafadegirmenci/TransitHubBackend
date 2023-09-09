using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class TeamRepository : Repository<Team>, ITeamRepository
{
    public TeamRepository(ApplicationDbContext context) : base(context)
    {
    }
}