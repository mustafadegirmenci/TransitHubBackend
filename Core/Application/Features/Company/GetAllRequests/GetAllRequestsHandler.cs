using Application.Repositories;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Company.GetAllRequests;

public class GetAllRequestsHandler : IRequestHandler<GetAllRequestsRequest, GetAllRequestsResponse>
{
    private readonly IRequestRepository _requestRepository;
    
    public GetAllRequestsHandler(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<GetAllRequestsResponse> Handle(GetAllRequestsRequest request, CancellationToken cancellationToken)
    {
        var allRequests = await _requestRepository.GetAllAsync();
        
        return new GetAllRequestsResponse
        {
            AllRequests = allRequests.ToArray()
        };
    }
}