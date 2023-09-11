using MediatR;

namespace Application.Features.Company.AssignVehicle;

public class AssignVehicleRequest : IRequest<AssignVehicleResponse>
{
    public int TeamId { get; set; }
    public int VehicleId { get; set; }
}