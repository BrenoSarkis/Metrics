using static Metrics.Domain.Boundaries.Dtos.TeamDto;

namespace Metrics.Domain.Boundaries.Dtos;

public class TeamDto {
    public int Id { get; set; }
    public string Name { get; set; }
    public BacklogDto Backlog { get; set; }

    public TeamDto(int id, String name, BacklogDto backlog) {
        Id = id;
        Name = name;
        Backlog = backlog;
    }

    public class BacklogDto {
        public List<WorkItemDto> Items { get; set; }

        public BacklogDto(List<WorkItemDto> items) {
            Items = items;
        }
    }

    public class WorkItemDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? MarkedAsInProgress { get; set; }
        public DateTime? MarkedAsInDone { get; set; }

        public WorkItemDto(Int32 id, String title, DateTime? markedAsInProgress, DateTime? markedAsInDone) {
            Id = id;
            Title = title;
            MarkedAsInProgress = markedAsInProgress;
            MarkedAsInDone = markedAsInDone;
        }
    }
}

public static class DtoExtensions {
    public static TeamDto ToDto(this Team team) {
        return new TeamDto(team.Id, team.Name, team.Backlog.ToDto());
    }    
    
    public static BacklogDto ToDto(this Backlog backlog) {
        var workItems = backlog.Items.Select(x => x.ToDto());
        return new BacklogDto(workItems.ToList());
    }        
    
    public static WorkItemDto ToDto(this WorkItem workItem) {
        return new WorkItemDto(workItem.Id, workItem.Title, workItem.MarkedAsInProgress, workItem.MarkedAsInDone);
    }
}
