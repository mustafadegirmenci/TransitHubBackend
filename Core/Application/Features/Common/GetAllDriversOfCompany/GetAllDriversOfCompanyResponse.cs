using Domain.Entities;

namespace Application.Features.Common.GetAllDriversOfCompany;

public class GetAllDriversOfCompanyResponse
{
    public ICollection<Driver> Drivers { get; set; }
}