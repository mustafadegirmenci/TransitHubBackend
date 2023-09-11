using Application.Repositories.Relationship;
using Domain.Relationships;
using MediatR;

namespace Application.Features.Company.AssignDriver;

public class AssignDriverHandler : IRequestHandler<AssignDriverRequest, AssignDriverResponse>
{
    private readonly IDriverVehicleRepository _driverVehicleRepository;
    
    public AssignDriverHandler(IDriverVehicleRepository driverVehicleRepository)
    {
        _driverVehicleRepository = driverVehicleRepository;
    }

    public async Task<AssignDriverResponse> Handle(AssignDriverRequest request, CancellationToken cancellationToken)
    {
        var newRelationship = new DriverVehicle
        {
            DriverId = request.DriverId,
            VehicleId = request.VehicleId
        };
        
        var newRelationshipId = await _driverVehicleRepository.AddAsync(newRelationship);

        return new AssignDriverResponse
        {
            RelationshipId = newRelationshipId
        };
    }
}