using Domain.Enums;
using MediatR;

namespace Application.Features.Customer.CreateReservation;

public class CreateReservationRequest : IRequest<CreateReservationResponse>
{
    public DateTimeOffset Date { get; set; }
    public ReservationStatus Status { get; set; }
    
    public int ResponseId { get; set; }
}