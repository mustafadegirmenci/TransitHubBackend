using Application.Repositories.Entity;
using Domain.Entities;
using MediatR;

namespace Application.Features.Company.CreateResponse;

public class CreateOfferHandler : IRequestHandler<CreateOfferRequest, CreateOfferResponse>
{
    private readonly IOfferRepository _offerRepository;
    
    public CreateOfferHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task<CreateOfferResponse> Handle(CreateOfferRequest request, CancellationToken cancellationToken)
    {
        var newResponse = new Offer
        {
            RequestId = request.RequestId,
            TeamSize = request.TeamSize,
            Price = request.Price,
            CompanyId = request.CompanyId,
            VehicleId = request.VehicleId,
            DriverId = request.DriverId
        };
        
        var newResponseId = await _offerRepository.AddAsync(newResponse);

        return new CreateOfferResponse
        {
            ResponseId = newResponseId
        };
    }
}