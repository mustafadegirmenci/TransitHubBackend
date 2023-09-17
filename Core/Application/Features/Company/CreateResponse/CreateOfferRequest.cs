using MediatR;

namespace Application.Features.Company.CreateResponse;

public class CreateOfferRequest : IRequest<CreateOfferResponse>
{
    public int RequestId { get; set; }
    public int TeamSize { get; set; }
    public int Price { get; set; }

    public int DriverId { get; set; }
    public int VehicleId { get; set; }

    public int CompanyId { get; set; }
}
