using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Reservation : BaseEntity
{
    public DateTimeOffset Date { get; set; }
    public ReservationStatus Status { get; set; }
    
    public int ResponseId { get; set; }
}