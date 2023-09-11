using Domain.Common;

namespace Domain.Relationships;

public class TeamVehicle : BaseEntity
{
    public int TeamId { get; set; }
    public int VehicleId { get; set; }
}