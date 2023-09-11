using Domain.Enums;
using MediatR;

namespace Application.Features.Customer.CreateRequest;

public class CreateRequestRequest : IRequest<CreateRequestResponse>
{
    public TransportationType TransportationType { get; set; }
    public DateTimeOffset EarliestAcceptableDate { get; set; }
    public DateTimeOffset LatestAcceptableDate { get; set; }
    public int UserId { get; set; }
}