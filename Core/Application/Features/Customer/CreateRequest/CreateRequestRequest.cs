using MediatR;

namespace Application.Features.Customer.CreateRequest;

public class CreateRequestRequest : IRequest<CreateRequestResponse>
{
    public string TransportationType { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    public int UserId { get; set; }
}