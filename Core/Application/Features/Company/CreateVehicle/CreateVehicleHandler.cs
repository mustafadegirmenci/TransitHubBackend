using Application.Repositories.Entity;
using Domain.Entities;
using MediatR;

namespace Application.Features.Company.CreateVehicle;

public class CreateVehicleHandler : IRequestHandler<CreateVehicleRequest, CreateVehicleResponse>
{
    private readonly IVehicleRepository _vehicleRepository;
    
    public CreateVehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<CreateVehicleResponse> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        var newVehicle = new Vehicle
        {
            Brand = request.Brand,
            Model = request.Model,
            Year = request.Year,
            VehicleType = request.VehicleType,
            CompanyId = request.CompanyId
        };
        
        var newVehicleId = await _vehicleRepository.AddAsync(newVehicle);

        return new CreateVehicleResponse
        {
            VehicleId = newVehicleId
        };
    }
}