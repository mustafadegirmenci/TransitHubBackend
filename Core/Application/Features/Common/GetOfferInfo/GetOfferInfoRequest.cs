using MediatR;

namespace Application.Features.Common.GetOfferInfo;

public class GetOfferInfoRequest : IRequest<GetOfferInfoResponse>
{
    public int OfferId { get; set; }
}