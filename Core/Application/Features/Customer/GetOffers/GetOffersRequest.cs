using MediatR;

namespace Application.Features.Customer.GetOffers;

public class GetOffersRequest : IRequest<GetOffersResponse>
{
    public int RequestId { get; set; }
}