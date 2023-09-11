using MediatR;

namespace Application.Features.Customer.GetRequestsById;

public class GetRequestsByIdRequest : IRequest<GetRequestsByIdResponse>
{
    public int UserId { get; set; }
}