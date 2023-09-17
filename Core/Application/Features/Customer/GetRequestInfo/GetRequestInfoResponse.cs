namespace Application.Features.Customer.GetRequestInfo;

public class GetRequestInfoResponse
{
    public string TransportationType { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }

    public int[] OfferIds { get; set; }
}