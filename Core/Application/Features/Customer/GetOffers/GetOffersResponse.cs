using Domain.Entities;

namespace Application.Features.Customer.GetOffers;

public class GetOffersResponse
{
    public ICollection<Offer> Offers { get; set; }
}