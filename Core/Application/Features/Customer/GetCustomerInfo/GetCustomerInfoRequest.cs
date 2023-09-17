using MediatR;

namespace Application.Features.Customer.GetCustomerInfo;

public class GetCustomerInfoRequest : IRequest<GetCustomerInfoResponse>
{
    public int CustomerId { get; set; }
}