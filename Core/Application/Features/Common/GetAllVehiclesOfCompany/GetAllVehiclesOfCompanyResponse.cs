using Domain.Entities;

namespace Application.Features.Common.GetAllVehiclesOfCompany;

public class GetAllVehiclesOfCompanyResponse
{
    public ICollection<Vehicle> Vehicles { get; set; }
}