using Metrics.Domain.Boundaries.ApplicationServices;
using Metrics.Domain.Boundaries.Dtos;
using Metrics.Domain.Boundaries.ExternalServices;
using Metrics.Domain.Boundaries.Repositories;

namespace Metrics.Domain.Application.Services;

public class TeamService : ITeamService {
    private readonly ITeamDataProvider dataProvider;
    private readonly ITeamRepository teamRepository;

    public TeamService(ITeamDataProvider dataProvider, ITeamRepository teamRepository) {
        this.dataProvider = dataProvider;
        this.teamRepository = teamRepository;
    }

    public IList<TeamDto> GetTeams() {
        var result = new List<TeamDto>();

        try {
            result.AddRange(dataProvider.GetTeams());
        } catch (Exception) {
            result.AddRange(teamRepository.GetTeams().Select(x => x.ToDto()));
        }

        return result;
    }

    public TimeSpan GetTeamCycleTime(Int32 id) {
        var team = teamRepository.GetById(id);
        return team.CalculateAverageCycleTime();
    }

    //This illustrates one of the problems I see in loose services like this, transaction control is harder
    //creating a transaction that wraps all db calls is harder, whereas if you have command/command handler
    //you can use a decorator to that behavior once at the end of the handler (since it does 1 thing only)
    public void Synchronize() {
        var teamsFromSource = dataProvider.GetTeams();
        var localTeams = teamRepository.GetTeams().Select(x => x.ToDto());

        if (teamsFromSource.SequenceEqual(localTeams)) {
            return;
        }

        teamRepository.EraseAllData();

        foreach (var team in teamsFromSource) {
            var backlog = new Backlog();
            var workItems = team.Backlog.Items.Select(x => new WorkItem(x.Id, x.Title, x.MarkedAsInProgress, x.MarkedAsInDone)).ToArray();
            backlog.AddWorkItems(workItems);
            teamRepository.Save(new Team(team.Id, team.Name, backlog));
        }
    }
}