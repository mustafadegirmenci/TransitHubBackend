using Application.Repositories.Entity;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Company.CreateResponse;

public class CreateResponseHandler : IRequestHandler<CreateResponseRequest, CreateResponseResponse>
{
    private readonly IResponseRepository _responseRepository;
    
    public CreateResponseHandler(IResponseRepository responseRepository)
    {
        _responseRepository = responseRepository;
    }

    public async Task<CreateResponseResponse> Handle(CreateResponseRequest request, CancellationToken cancellationToken)
    {
        var newResponse = new Response
        {
            Status = ResponseStatus.Active,
            TeamId = request.TeamId,
            RequestId = request.RequestId,
            Price = request.Price
        };
        
        var newResponseId = await _responseRepository.AddAsync(newResponse);

        return new CreateResponseResponse
        {
            ResponseId = newResponseId
        };
    }
}