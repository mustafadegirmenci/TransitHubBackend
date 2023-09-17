using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Common.GetVehicleInfo;

public class GetVehicleInfoHandler : IRequestHandler<GetVehicleInfoRequest, GetVehicleInfoResponse>
{
    private readonly IVehicleRepository _vehicleRepository;
    
    public GetVehicleInfoHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<GetVehicleInfoResponse> Handle(GetVehicleInfoRequest request, CancellationToken cancellationToken)
    {
        var vehicleInfo = await _vehicleRepository.GetByIdAsync(request.VehicleId);
        
        return new GetVehicleInfoResponse
        {
            Brand = vehicleInfo.Brand,
            Model = vehicleInfo.Model,
            VehicleType = vehicleInfo.VehicleType,
            Year = vehicleInfo.Year,
        };
    }
}