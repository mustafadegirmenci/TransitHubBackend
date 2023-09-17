using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Customer.GetRequestInfo;

public class GetRequestInfoHandler : IRequestHandler<GetRequestInfoRequest, GetRequestInfoResponse>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IOfferRepository _offerRepository;
    
    public GetRequestInfoHandler(IRequestRepository requestRepository, IOfferRepository offerRepository)
    {
        _requestRepository = requestRepository;
        _offerRepository = offerRepository;
    }

    public async Task<GetRequestInfoResponse> Handle(GetRequestInfoRequest request, CancellationToken cancellationToken)
    {
        var requestInfo = await _requestRepository.GetByIdAsync(request.RequestId);
        var allOffers = await _offerRepository.GetAllAsync();
        
        return new GetRequestInfoResponse
        {
            TransportationType = requestInfo.TransportationType,
            Source = requestInfo.Source,
            Destination = requestInfo.Destination,
            OfferIds = allOffers.Where(o => o.RequestId == request.RequestId).Select(o => o.Id).ToArray()
        };
    }
}