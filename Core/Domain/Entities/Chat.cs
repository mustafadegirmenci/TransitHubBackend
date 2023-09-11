using Domain.Common;

namespace Domain.Entities;

public class Chat : BaseEntity
{
    public string Title { get; set; }
    
    public int CompanyId { get; set; }
    public int UserId { get; set; }
}