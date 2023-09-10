using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Request : BaseEntity
{
    public RequestStatus Status { get; set; }
    public TransportationType TransportationType { get; set; }
    public DateTimeOffset EarliestAcceptableDate { get; set; }
    public DateTimeOffset LatestAcceptableDate { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<Response> Response { get; set; }
}