using System.Collections.Immutable;

namespace Metrics.Domain;

public class ValueObject {
}

public class Backlog : ValueObject
{
    private readonly List<WorkItem> workItems = new();
    public IReadOnlyList<WorkItem> Items => workItems.ToImmutableList();

    public void AddWorkItems(params WorkItem[] items) {
        workItems.AddRange(items);
    }

    public TimeSpan CalculateAverageLifeCycle() {
        if (Items.Count == 0) {
            return TimeSpan.Zero;
        }

        var totalLifeCycle = TimeSpan.Zero;

        foreach (var workItem in Items) {
            var cycleTime = workItem.CalculateCycleTime();
            totalLifeCycle += cycleTime;
        }

        var averageLifeCycle = TimeSpan.FromTicks(totalLifeCycle.Ticks / Items.Count);
        return averageLifeCycle;
    }
}