using MediatR;

namespace Application.Features.Company.GetCompanyInfo;

public class GetCompanyInfoRequest : IRequest<GetCompanyInfoResponse>
{
    public int CompanyId { get; set; }
}