using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Response : BaseEntity
{
    public ResponseStatus Status { get; set; }
    public Team OfferedTeam { get; set; }
    public Company Company { get; set; }
    public Request Request { get; set; }
    
    public Reservation? Reservation { get; set; }
}