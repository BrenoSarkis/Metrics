using Metrics.Domain.Boundaries.Dtos;

namespace Metrics.Domain.Boundaries.Repositories;

public interface ITeamRepository{
    Team GetById(int id);
    IList<Team> GetTeams();
    //I would never expose something like this, and Synchornization should be done through reconciliation not this
    void EraseAllData();
    void Save(Team team);
}
