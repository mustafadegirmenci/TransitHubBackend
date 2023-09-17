using MediatR;

namespace Application.Features.Common.GetVehicleInfo;

public class GetVehicleInfoRequest : IRequest<GetVehicleInfoResponse>
{
    public int VehicleId { get; set; }
}