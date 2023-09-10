using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Response : BaseEntity
{
    public ResponseStatus Status { get; set; }
    
    public int TeamId { get; set; }
    public Team OfferedTeam { get; set; }
    
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    
    public int RequestId { get; set; }
    public Request Request { get; set; }
    
    public int ReservationId { get; set; }
    public Reservation? Reservation { get; set; }
}