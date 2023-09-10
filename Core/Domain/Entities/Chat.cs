using Domain.Common;

namespace Domain.Entities;

public class Chat : BaseEntity
{
    public string Title { get; set; }
    
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<Message> Messages { get; set; }
}