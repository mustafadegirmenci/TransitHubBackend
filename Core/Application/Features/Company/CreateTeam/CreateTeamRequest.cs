using MediatR;

namespace Application.Features.Company.CreateTeam;

public class CreateTeamRequest : IRequest<CreateTeamResponse>
{
    public string Name { get; set; }
    public int CompanyId { get; set; }
}