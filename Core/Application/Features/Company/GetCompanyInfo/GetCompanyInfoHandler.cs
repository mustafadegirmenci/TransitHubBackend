using Application.Repositories.Entity;
using MediatR;

namespace Application.Features.Company.GetCompanyInfo;

public class GetCompanyInfoHandler : IRequestHandler<GetCompanyInfoRequest, GetCompanyInfoResponse>
{
    private readonly ICompanyRepository _companyRepository;
    
    public GetCompanyInfoHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<GetCompanyInfoResponse> Handle(GetCompanyInfoRequest request, CancellationToken cancellationToken)
    {
        var companyInfo = await _companyRepository.GetByIdAsync(request.CompanyId);
        
        return new GetCompanyInfoResponse
        {
            Name = companyInfo.Name,
            FoundingDate = companyInfo.FoundingDate
        };
    }
}