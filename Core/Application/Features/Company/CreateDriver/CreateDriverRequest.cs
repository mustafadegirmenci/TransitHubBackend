using MediatR;

namespace Application.Features.Company.CreateDriver;

public class CreateDriverRequest : IRequest<CreateDriverResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Experience { get; set; }
    
    public int CompanyId { get; set; }
}