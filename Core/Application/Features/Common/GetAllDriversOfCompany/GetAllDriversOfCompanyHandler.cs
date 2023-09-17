using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Common.GetAllDriversOfCompany;

public class GetAllDriversOfCompanyHandler : IRequestHandler<GetAllDriversOfCompanyRequest, GetAllDriversOfCompanyResponse>
{
    private readonly IDriverRepository _driverRepository;
    
    public GetAllDriversOfCompanyHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<GetAllDriversOfCompanyResponse> Handle(GetAllDriversOfCompanyRequest request, CancellationToken cancellationToken)
    {
        var allDrivers = await _driverRepository.GetAllAsync();
        
        return new GetAllDriversOfCompanyResponse
        {
            Drivers = allDrivers.Where(d => d.CompanyId == request.CompanyId).ToArray()
        };
    }
}