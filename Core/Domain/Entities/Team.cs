using Domain.Common;

namespace Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    
    public int CompanyId { get; set; }
}
