namespace Metrics.Domain;

public class Team 
{
    public int Id { get;  }
    public string Name { get; }
    private static Backlog backlog => new();

    public Team(int id, String name) {
        Id = id;
        Name = name;
    }

    public TimeSpan CalculateAverageCycleTime() {
        return backlog.CalculateAverageLifeCycle();
    }

    public void AddWorkItems(params WorkItem[] items) {
        backlog.AddWorkItems(items);
    }
}