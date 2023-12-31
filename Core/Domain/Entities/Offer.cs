﻿using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Offer : BaseEntity
{
    public OfferStatus Status { get; set; }
    
    public int RequestId { get; set; }
    public int TeamSize { get; set; }
    public int Price { get; set; }

    public int DriverId { get; set; }
    public int VehicleId { get; set; }
    
    public int CompanyId { get; set; }
}