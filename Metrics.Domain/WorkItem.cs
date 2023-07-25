namespace Metrics.Domain;

public class WorkItem
{
    public int Id { get; }
    public string Title { get; }
    public DateTime? MarkedAsInProgress { get; }
    public DateTime? MarkedAsInDone { get; }

    public WorkItem(int id, String title, DateTime? markedAsInProgress, DateTime? markedAsInDone) {
        Id = id;
        Title = title;
        MarkedAsInProgress = markedAsInProgress;
        MarkedAsInDone = markedAsInDone;
    }

    public TimeSpan CalculateCycleTime() {
        if (MarkedAsInDone is null || MarkedAsInProgress is null) {
            return TimeSpan.Zero;
        }

        return MarkedAsInDone.Value - MarkedAsInProgress.Value;
    }
}