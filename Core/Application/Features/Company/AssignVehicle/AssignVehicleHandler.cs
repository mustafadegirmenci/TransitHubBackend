using Application.Repositories.Relationship;
using Domain.Relationships;
using MediatR;

namespace Application.Features.Company.AssignVehicle;

public class AssignVehicleHandler : IRequestHandler<AssignVehicleRequest, AssignVehicleResponse>
{
    private readonly ITeamVehicleRepository _teamVehicleRepository;
    
    public AssignVehicleHandler(ITeamVehicleRepository teamVehicleRepository)
    {
        _teamVehicleRepository = teamVehicleRepository;
    }

    public async Task<AssignVehicleResponse> Handle(AssignVehicleRequest request, CancellationToken cancellationToken)
    {
        var newRelationship = new TeamVehicle
        {
            TeamId = request.TeamId,
            VehicleId = request.VehicleId
        };
        
        var newRelationshipId = await _teamVehicleRepository.AddAsync(newRelationship);

        return new AssignVehicleResponse
        {
            RelationshipId = newRelationshipId
        };
    }
}