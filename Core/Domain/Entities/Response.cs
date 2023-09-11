using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Response : BaseEntity
{
    public ResponseStatus Status { get; set; }
    
    public int TeamId { get; set; }
    public int RequestId { get; set; }
    public int ReservationId { get; set; }
}