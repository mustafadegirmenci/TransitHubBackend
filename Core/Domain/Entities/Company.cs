using Domain.Common;

namespace Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public string FoundingDate { get; set; }
    
    public ICollection<Chat> Chats { get; set; }
    public ICollection<Response> Responses { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Team> Teams { get; set; }
}