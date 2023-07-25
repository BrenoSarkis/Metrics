namespace Metrics.Domain;

public class Team 
{
    public int Id { get;  }
    public string Name { get; }
    public Backlog Backlog { get; }

    public Team(int id, String name, Backlog backlog) {
        Id = id;
        Name = name;
        Backlog = backlog;
    }

    public TimeSpan CalculateAverageCycleTime() {
        return Backlog.CalculateAverageLifeCycle();
    }

    public void AddWorkItems(params WorkItem[] items) {
        Backlog.AddWorkItems(items);
    }
}