using MediatR;

namespace Application.Features.Common.GetAllMessagesOfAnOffer;

public class GetAllMessagesRequest : IRequest<GetAllMessagesResponse>
{
    public int OfferId { get; set; }
}