using Application.Repositories.Entity;
using Domain.Entities;
using MediatR;

namespace Application.Features.Company.CreateTeam;

public class CreateTeamHandler : IRequestHandler<CreateTeamRequest, CreateTeamResponse>
{
    private readonly ITeamRepository _teamRepository;
    
    public CreateTeamHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<CreateTeamResponse> Handle(CreateTeamRequest request, CancellationToken cancellationToken)
    {
        var newTeam = new Team
        {
            Name = request.Name,
            CompanyId = request.CompanyId,
        };
        
        var newTeamId = await _teamRepository.AddAsync(newTeam);

        return new CreateTeamResponse
        {
            TeamId = newTeamId
        };
    }
}