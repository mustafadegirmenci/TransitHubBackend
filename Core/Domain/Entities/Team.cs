using Domain.Common;

namespace Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    
    public Company Company { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}
