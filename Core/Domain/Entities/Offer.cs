using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Offer : BaseEntity
{
    public OfferStatus Status { get; set; }
    
    public int RequestId { get; set; }
    public int TeamSize { get; set; }
    public int Price { get; set; }

    public string DriverName { get; set; }
    public string DriverSurname { get; set; }

    public string VehicleBrand { get; set; }
    public string VehicleModel { get; set; }
    public int VehicleYear { get; set; }
}