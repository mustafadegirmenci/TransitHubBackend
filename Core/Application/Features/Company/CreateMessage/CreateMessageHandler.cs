using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Company.CreateMessage;

public class CreateMessageHandler : IRequestHandler<CreateMessageRequest, CreateMessageResponse>
{
    private readonly IMessageRepository _messageRepository;
    
    public CreateMessageHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<CreateMessageResponse> Handle(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var newMessage = new Domain.Entities.Message
        {
            OfferId = request.OfferId,
            CustomerId = request.CustomerId,
            CompanyId = request.CompanyId,
            Body = request.Body,
            DateSent = DateTimeOffset.Now
        };
        
        var newMessageId = await _messageRepository.AddAsync(newMessage);

        return new CreateMessageResponse
        {
            MessageId = newMessageId
        };
    }
};