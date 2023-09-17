using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Request : BaseEntity
{
    public RequestStatus Status { get; set; }
    public string TransportationType { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    
    public int UserId { get; set; }
}