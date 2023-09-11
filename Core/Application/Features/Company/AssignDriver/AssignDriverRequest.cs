using MediatR;

namespace Application.Features.Company.AssignDriver;

public class AssignDriverRequest : IRequest<AssignDriverResponse>
{
    public int DriverId { get; set; }
    public int VehicleId { get; set; }
}