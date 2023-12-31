﻿using Domain.Common;

namespace Domain.Entities;

public class Message : BaseEntity
{
    public string Body { get; set; }
    public DateTimeOffset DateSent { get; set; }
    
    public int OfferId { get; set; }
    public int? CustomerId { get; set; }
    public int? CompanyId { get; set; }
}