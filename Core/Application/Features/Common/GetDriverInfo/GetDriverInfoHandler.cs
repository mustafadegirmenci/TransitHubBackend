using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Common.GetDriverInfo;

public class GetDriverInfoHandler : IRequestHandler<GetDriverInfoRequest, GetDriverInfoResponse>
{
    private readonly IDriverRepository _driverRepository;
    
    public GetDriverInfoHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<GetDriverInfoResponse> Handle(GetDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driverInfo = await _driverRepository.GetByIdAsync(request.DriverId);
        
        return new GetDriverInfoResponse
        {
            Name = driverInfo.Name,
            Surname = driverInfo.Surname,
            ExperienceInYears = driverInfo.ExperienceInYears,
        };
    }
}