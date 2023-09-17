using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Customer.GetOffers;

public class GetOffersHandler : IRequestHandler<GetOffersRequest, GetOffersResponse>
{
    private readonly IOfferRepository _offerRepository;
    
    public GetOffersHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task<GetOffersResponse> Handle(GetOffersRequest request, CancellationToken cancellationToken)
    {
        var allOffers = await _offerRepository.GetAllAsync();
        
        return new GetOffersResponse
        {
            Offers = allOffers.Where(r => r.RequestId == request.RequestId).ToArray()
        };
    }
}