using MediatR;

namespace Application.Features.Common.GetAllDriversOfCompany;

public class GetAllDriversOfCompanyRequest : IRequest<GetAllDriversOfCompanyResponse>
{
    public int CompanyId { get; set; }
}