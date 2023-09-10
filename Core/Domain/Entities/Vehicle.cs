using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Vehicle : BaseEntity
{
    public VehicleType VehicleType { get; set; }
    
    public int TeamId { get; set; }
    public Team Team { get; set; }
    
    public int DriverId { get; set; }
    public Driver Driver { get; set; }
}