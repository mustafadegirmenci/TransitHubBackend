using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Customer.GetRequestsById;

public class GetRequestsByIdHandler : IRequestHandler<GetRequestsByIdRequest, GetRequestsByIdResponse>
{
    private readonly IRequestRepository _requestRepository;
    
    public GetRequestsByIdHandler(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<GetRequestsByIdResponse> Handle(GetRequestsByIdRequest request, CancellationToken cancellationToken)
    {
        var allRequests = await _requestRepository.GetAllAsync();
        
        return new GetRequestsByIdResponse
        {
            Requests = allRequests.Where(r => r.UserId == request.UserId).ToArray()
        };
    }
}