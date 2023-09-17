using MediatR;

namespace Application.Features.Common.GetAllVehiclesOfCompany;

public class GetAllVehiclesOfCompanyRequest : IRequest<GetAllVehiclesOfCompanyResponse>
{
    public int CompanyId { get; set; }
}