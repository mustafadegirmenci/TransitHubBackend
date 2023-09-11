using Domain.Entities;

namespace Application.Features.Customer.GetRequestsById;

public class GetRequestsByIdResponse
{
    public ICollection<Request> Requests { get; set; }
}