namespace Metrics.Domain.Boundaries.Dtos;

public class TeamDto 
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TeamDto(int id, String name) {
        Id = id;
        Name = name;
    }
}

public static class DtoExtensions{
    public static TeamDto ToDto(this Team team) {
        return new TeamDto(team.Id, team.Name);
    }
}
