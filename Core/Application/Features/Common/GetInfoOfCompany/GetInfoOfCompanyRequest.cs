using MediatR;

namespace Application.Features.Common.GetInfoOfCompany;

public class GetInfoOfCompanyRequest : IRequest<GetInfoOfCompanyResponse>
{
    public int CompanyId { get; set; }
}