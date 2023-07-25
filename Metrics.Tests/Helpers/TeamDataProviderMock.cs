using Metrics.Domain.Boundaries.Dtos;
using Metrics.Domain.Boundaries.ExternalServices;

namespace Metrics.Tests.Helpers;

public class TeamDataProviderMock : ITeamDataProvider
{
    private List<TeamDto> teams = new();
    private bool calledGetTeams;
    private bool shouldFail;

    public IList<TeamDto> GetTeams()
    {
        calledGetTeams = true;

        if (shouldFail)
        {
            throw new Exception("Service is out.");
        }

        return teams;
    }

    public void AssumeExistingTeams(params TeamDto[] teams)
    {
        this.teams.AddRange(teams);
    }

    public bool CalledGetTeams()
    {
        return calledGetTeams;
    }

    public void EnsureThatCallingGetTeamsWillCrash()
    {
        shouldFail = true;
    }
}