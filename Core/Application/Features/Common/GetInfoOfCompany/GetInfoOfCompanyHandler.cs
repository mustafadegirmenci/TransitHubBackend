using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Common.GetInfoOfCompany;

public class GetInfoOfCompanyHandler : IRequestHandler<GetInfoOfCompanyRequest, GetInfoOfCompanyResponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IReviewRepository _reviewRepository;
    
    public GetInfoOfCompanyHandler(ICompanyRepository companyRepository, IDriverRepository driverRepository, IVehicleRepository vehicleRepository, IReviewRepository reviewRepository)
    {
        _companyRepository = companyRepository;
        this._driverRepository = driverRepository;
        _vehicleRepository = vehicleRepository;
        _reviewRepository = reviewRepository;
    }

    public async Task<GetInfoOfCompanyResponse> Handle(GetInfoOfCompanyRequest request, CancellationToken cancellationToken)
    {
        var driverInfo = await _companyRepository.GetByIdAsync(request.CompanyId);
        var allReviews = await _reviewRepository.GetAllAsync();
        var allVehicles = await _vehicleRepository.GetAllAsync();
        var allDrivers = await _driverRepository.GetAllAsync();
        
        return new GetInfoOfCompanyResponse
        {
            Name = driverInfo.Name,
            FoundingDate = driverInfo.FoundingDate,
            DriverIds = allDrivers.Where(d => d.CompanyId == request.CompanyId).Select(d => d.Id).ToArray(),
            VehicleIds = allVehicles.Where(d => d.CompanyId == request.CompanyId).Select(d => d.Id).ToArray(),
            ReviewIds = allReviews.Where(d => d.CompanyId == request.CompanyId).Select(d => d.Id).ToArray(),
        };
    }
}