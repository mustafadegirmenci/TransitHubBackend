using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Common.GetAllVehiclesOfCompany;

public class GetAllVehiclesOfCompanyHandler : IRequestHandler<GetAllVehiclesOfCompanyRequest, GetAllVehiclesOfCompanyResponse>
{
    private readonly IVehicleRepository _vehicleRepository;
    
    public GetAllVehiclesOfCompanyHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<GetAllVehiclesOfCompanyResponse> Handle(GetAllVehiclesOfCompanyRequest request, CancellationToken cancellationToken)
    {
        var allVehicles = await _vehicleRepository.GetAllAsync();
        
        return new GetAllVehiclesOfCompanyResponse
        {
            Vehicles = allVehicles.Where(d => d.CompanyId == request.CompanyId).ToArray()
        };
    }
}