using MediatR;

namespace Application.Features.Customer.GetRequestInfo;

public class GetRequestInfoRequest : IRequest<GetRequestInfoResponse>
{
    public int RequestId { get; set; }
}