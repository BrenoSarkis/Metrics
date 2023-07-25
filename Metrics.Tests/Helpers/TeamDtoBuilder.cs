using Metrics.Domain.Boundaries.Dtos;

namespace Metrics.Tests.Helpers;

public class TeamDtoBuilder {
    public static TeamDto TeamA = new(1, "Team A", BacklogDtoBuilder.BacklogA);
    public static TeamDto TeamB = new(2, "Team B", BacklogDtoBuilder.BacklogB);
}

public class BacklogDtoBuilder {
    public static TeamDto.BacklogDto BacklogA = new TeamDto.BacklogDto(new List<TeamDto.WorkItemDto> {
        WorkItemDtoBuilder.WorkItemA
    });    
    
    public static TeamDto.BacklogDto BacklogB = new TeamDto.BacklogDto(new List<TeamDto.WorkItemDto> {
        WorkItemDtoBuilder.WorkItemB
    });
}

public class WorkItemDtoBuilder {
    public static TeamDto.WorkItemDto WorkItemA = new(1, "WI A", new DateTime(2023, 7, 24, 12, 0, 0), new DateTime(2023, 7, 25, 0, 0, 0));
    public static TeamDto.WorkItemDto WorkItemB = new(2, "WI B", new DateTime(2023, 7, 23, 12, 0, 0), new DateTime(2023, 7, 24, 0, 0, 0));
}