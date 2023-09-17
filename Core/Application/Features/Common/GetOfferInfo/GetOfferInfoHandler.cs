using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Common.GetOfferInfo;

public class GetOfferInfoHandler : IRequestHandler<GetOfferInfoRequest, GetOfferInfoResponse>
{
    private readonly IOfferRepository _offerRepository;
    
    public GetOfferInfoHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task<GetOfferInfoResponse> Handle(GetOfferInfoRequest request, CancellationToken cancellationToken)
    {
        var offer = await _offerRepository.GetByIdAsync(request.OfferId);
        
        return new GetOfferInfoResponse
        {
            TeamSize = offer.TeamSize,
            Price = offer.Price,
            VehicleId = offer.VehicleId,
            DriverId = offer.DriverId,
            CompanyId = offer.CompanyId,
        };
    }
}