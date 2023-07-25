using Metrics.Domain.Boundaries.Dtos;
using Metrics.Domain.Boundaries.Repositories;

namespace Metrics.Domain.Application.Repositories;

//this would use a real database of any sort
public class TeamRepository : ITeamRepository {
    private readonly List<Team> teams = new();

    public Team GetById(Int32 id) {
        return teams.First(x => x.Id == id);
    }

    public IList<Team> GetTeams() {
        return teams;
    }

    public void EraseAllData() {
        teams.Clear();
    }

    public void Save(Team team) {
        teams.Add(team);
    }
}