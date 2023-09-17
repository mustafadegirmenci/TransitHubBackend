using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Customer.GetCustomerInfo;

public class GetCustomerInfoHandler : IRequestHandler<GetCustomerInfoRequest, GetCustomerInfoResponse>
{
    private readonly ICustomerRepository _customerRepository;
    
    public GetCustomerInfoHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetCustomerInfoResponse> Handle(GetCustomerInfoRequest request, CancellationToken cancellationToken)
    {
        var customerInfo = await _customerRepository.GetByIdAsync(request.CustomerId);
        
        return new GetCustomerInfoResponse
        {
            Name = customerInfo.Name,
            Surname = customerInfo.Surname
        };
    }
}