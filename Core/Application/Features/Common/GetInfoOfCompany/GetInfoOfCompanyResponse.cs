namespace Application.Features.Common.GetInfoOfCompany;

public class GetInfoOfCompanyResponse
{
    public string Name { get; set; }
    public string FoundingDate { get; set; }
    
    public int[] VehicleIds { get; set; }
    public int[] DriverIds { get; set; }
    public int[] ReviewIds { get; set; }
}