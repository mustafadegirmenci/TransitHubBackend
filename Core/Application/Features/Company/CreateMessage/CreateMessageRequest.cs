using MediatR;

namespace Application.Features.Company.CreateMessage;

public class CreateMessageRequest : IRequest<CreateMessageResponse>
{
    public string Body { get; set; }
    public DateTimeOffset DateSent { get; set; }
    
    public int OfferId { get; set; }
    
    public int? CustomerId { get; set; }
    public int? CompanyId { get; set; }
}