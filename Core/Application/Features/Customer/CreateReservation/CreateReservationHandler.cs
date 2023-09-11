using Application.Repositories.Entity;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customer.CreateReservation;

public class CreateReservationHandler : IRequestHandler<CreateReservationRequest, CreateReservationResponse>
{
    private readonly IReservationRepository _reservationRepository;

    public CreateReservationHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<CreateReservationResponse> Handle(CreateReservationRequest request, CancellationToken cancellationToken)
    {
        var newReservation = new Reservation
        {
            Date = request.Date,
            Status = request.Status,
            ResponseId = request.ResponseId
        };
        
        var newReservationId = await _reservationRepository.AddAsync(newReservation);
        
        //TODO: Update response status

        return new CreateReservationResponse
        {
            ReservationId = newReservationId
        };
    }
}