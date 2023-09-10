using Domain.Common;

namespace Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    
    public int ResponseId { get; set; }
    public Response Response { get; set; }
    
    public ICollection<Vehicle> Vehicles { get; set; }
}
