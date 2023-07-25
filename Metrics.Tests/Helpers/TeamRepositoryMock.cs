using Metrics.Domain;
using Metrics.Domain.Boundaries.Repositories;

namespace Metrics.Tests.Helpers;

public class TeamRepositoryMock : ITeamRepository
{
    private readonly List<Team> teams = new();

    public Team GetById(Int32 id) {
        return teams[id];
    }

    public IList<Team> GetTeams() {
        return teams;
    }

    public void EraseAllData()
    {
        teams.Clear();
    }

    public void Save(Team team)
    {
        teams.Add(team);

    }
}