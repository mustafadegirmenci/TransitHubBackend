using Domain.Common;

namespace Domain.Entities;

public class Vehicle : BaseEntity
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string VehicleType { get; set; }
    
    public int CompanyId { get; set; }
}