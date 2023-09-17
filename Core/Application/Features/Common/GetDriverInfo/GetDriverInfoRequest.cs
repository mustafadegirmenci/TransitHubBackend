using MediatR;

namespace Application.Features.Common.GetDriverInfo;

public class GetDriverInfoRequest : IRequest<GetDriverInfoResponse>
{
    public int DriverId { get; set; }
}