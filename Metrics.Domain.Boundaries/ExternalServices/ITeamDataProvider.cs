using Metrics.Domain.Boundaries.Dtos;

namespace Metrics.Domain.Boundaries.ExternalServices;

public interface ITeamDataProvider {
    IList<TeamDto> GetTeams();
}
