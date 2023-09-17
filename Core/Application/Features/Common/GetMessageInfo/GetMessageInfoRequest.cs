using MediatR;

namespace Application.Features.Common.GetMessageInfo;

public class GetMessageInfoRequest : IRequest<GetMessageInfoResponse>
{
    public int MessageId { get; set; }
}