﻿using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Vehicle : BaseEntity
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public VehicleType VehicleType { get; set; }
    
    public int CompanyId { get; set; }
}