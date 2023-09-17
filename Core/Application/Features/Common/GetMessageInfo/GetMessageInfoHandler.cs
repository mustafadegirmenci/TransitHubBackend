using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Common.GetMessageInfo;

public class GetMessageInfoHandler : IRequestHandler<GetMessageInfoRequest, GetMessageInfoResponse>
{
    private readonly IMessageRepository _messageRepository;
    
    public GetMessageInfoHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<GetMessageInfoResponse> Handle(GetMessageInfoRequest request, CancellationToken cancellationToken)
    {
        var messageInfo = await _messageRepository.GetByIdAsync(request.MessageId);
        
        return new GetMessageInfoResponse
        {
            Body = messageInfo.Body,
        };
    }
}