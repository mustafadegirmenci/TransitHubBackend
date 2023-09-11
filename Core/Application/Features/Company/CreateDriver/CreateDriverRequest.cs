using MediatR;

namespace Application.Features.Company.CreateDriver;

public class CreateDriverRequest : IRequest<CreateDriverResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int ExperienceInYears { get; set; }
    
    public int CompanyId { get; set; }
}