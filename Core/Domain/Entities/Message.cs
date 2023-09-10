using Domain.Common;

namespace Domain.Entities;

public class Message : BaseEntity
{
    public string Body { get; set; }
    public DateTimeOffset DateSent { get; set; }
    
    public int ChatId { get; set; }
    public Chat Chat { get; set; }
}