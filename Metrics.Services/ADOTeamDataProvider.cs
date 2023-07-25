using Metrics.Domain;
using Metrics.Domain.Boundaries.Dtos;
using Metrics.Domain.Boundaries.ExternalServices;

namespace Metrics.Services;

public class ADOTeamDataProvider : ITeamDataProvider {
    public IList<TeamDto> GetTeams() {
        //pretend this calls ADO

        var result = new List<TeamDto>();

        var workItemA = new TeamDto.WorkItemDto(1, "WI A", DateTime.Now.AddDays(-1), DateTime.Now);
        var teamABackLog = new TeamDto.BacklogDto(new List<TeamDto.WorkItemDto>(){ workItemA });
        var teamA = new TeamDto(1, "teamA", teamABackLog);
        result.Add(teamA);

        return result;
    }
}
