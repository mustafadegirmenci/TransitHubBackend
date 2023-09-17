using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Company.CreateDriver;

public class CreateDriverHandler : IRequestHandler<CreateDriverRequest, CreateDriverResponse>
{
    private readonly IDriverRepository _driverRepository;
    
    public CreateDriverHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<CreateDriverResponse> Handle(CreateDriverRequest request, CancellationToken cancellationToken)
    {
        var newDriver = new Domain.Entities.Driver
        {
            Name = request.Name,
            Surname = request.Surname,
            ExperienceInYears = request.Experience,
            
            CompanyId = request.CompanyId
        };
        
        var newDriverId = await _driverRepository.AddAsync(newDriver);

        return new CreateDriverResponse
        {
            DriverId = newDriverId
        };
    }
};