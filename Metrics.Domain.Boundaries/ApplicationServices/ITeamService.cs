using Metrics.Domain.Boundaries.Dtos;

namespace Metrics.Domain.Boundaries.ApplicationServices;

public interface ITeamService {
    IList<TeamDto> GetTeams();
    TimeSpan GetTeamCycleTime(int id);
    void Synchronize();
}
