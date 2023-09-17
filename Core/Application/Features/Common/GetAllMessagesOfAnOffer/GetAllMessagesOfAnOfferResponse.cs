using Domain.Entities;

namespace Application.Features.Common.GetAllMessagesOfAnOffer;

public class GetAllMessagesResponse
{
    public ICollection<Message> Messages { get; set; }
}