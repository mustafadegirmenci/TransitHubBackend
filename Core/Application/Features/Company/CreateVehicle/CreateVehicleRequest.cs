using MediatR;

namespace Application.Features.Company.CreateVehicle;

public class CreateVehicleRequest : IRequest<CreateVehicleResponse>
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string VehicleType { get; set; }
    
    public int CompanyId { get; set; }
}