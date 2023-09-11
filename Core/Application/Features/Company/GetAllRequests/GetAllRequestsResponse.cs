using Domain.Entities;

namespace Application.Features.Company.GetAllRequests;

public class GetAllRequestsResponse
{
    public ICollection<Request> AllRequests { get; set; }
}