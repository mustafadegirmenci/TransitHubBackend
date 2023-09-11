using Domain.Common;

namespace Domain.Relationships;

public class DriverVehicle : BaseEntity
{
    public int DriverId { get; set; }
    public int VehicleId { get; set; }
}