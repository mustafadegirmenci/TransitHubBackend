using Application.Repositories.Entity;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Customer.CreateRequest;

public class CreateRequestHandler : IRequestHandler<CreateRequestRequest, CreateRequestResponse>
{
    private readonly IRequestRepository _requestRepository;
    
    public CreateRequestHandler(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<CreateRequestResponse> Handle(CreateRequestRequest request, CancellationToken cancellationToken)
    {
        var newRequest = new Request
        {
            Status = RequestStatus.Active,
            TransportationType = request.TransportationType,
            Source = request.Source,
            Destination = request.Destination,
            UserId = request.UserId
        };
        
        var newRequestId = await _requestRepository.AddAsync(newRequest);

        return new CreateRequestResponse
        {
            RequestId = newRequestId,
            IsSuccess = true,
            Message = "Request created."
        };
    }
}