using Domain.Common;

namespace Domain.Entities;

public class Review : BaseEntity
{
    public string Title { get; set; }
    public string Body { get; set; }
    
    public Company Company { get; set; }
}