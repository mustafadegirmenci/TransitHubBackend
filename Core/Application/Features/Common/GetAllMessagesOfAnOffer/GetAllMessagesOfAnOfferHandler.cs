using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Common.GetAllMessagesOfAnOffer;

public class GetAllMessagesHandler : IRequestHandler<GetAllMessagesRequest, GetAllMessagesResponse>
{
    private readonly IMessageRepository _messageRepository;
    
    public GetAllMessagesHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<GetAllMessagesResponse> Handle(GetAllMessagesRequest request, CancellationToken cancellationToken)
    {
        var allDrivers = await _messageRepository.GetAllAsync();
        
        return new GetAllMessagesResponse
        {
            Messages = allDrivers.Where(d => d.OfferId == request.OfferId).ToArray()
        };
    }
}