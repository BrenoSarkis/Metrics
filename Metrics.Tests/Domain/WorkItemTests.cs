using FluentAssertions;
using Metrics.Domain;
using Xunit;

namespace Metrics.Tests.Domain;

public class WorkItemTests
{
    [Fact]
    public void Calculates_Its_On_Cycle_Time()
    {
        var markedAsInProgress = new DateTime(2023, 7, 24, 12, 0, 0);
        var markedAsDone = new DateTime(2023, 7, 25, 12, 0, 0);
        var workItem = new WorkItem(1, "Metrics WI", markedAsInProgress, markedAsDone);
        var expectedLifeCycle = TimeSpan.FromHours(24);

        var lifeCycle = workItem.CalculateCycleTime();

        lifeCycle.Should().Be(expectedLifeCycle);
    }

    [Fact]
    public void Life_Cycle_Is_Zero_If_Not_Marked_As_Done()
    {
        var markedAsInProgress = new DateTime(2023, 7, 24, 12, 0, 0);
        var workItem = new WorkItem(1, "Metrics WI", markedAsInProgress, null);
        var expectedLifeCycle = TimeSpan.Zero;

        var lifeCycle = workItem.CalculateCycleTime();

        lifeCycle.Should().Be(expectedLifeCycle);
    }

    [Fact]
    public void Life_Cycle_Is_Zero_If_Not_Marked_As_In_Progress()
    {
        var markedAsDone = new DateTime(2023, 7, 25, 12, 0, 0);
        var workItem = new WorkItem(1, "Metrics WI", null, markedAsDone);
        var expectedLifeCycle = TimeSpan.Zero;

        var lifeCycle = workItem.CalculateCycleTime();

        lifeCycle.Should().Be(expectedLifeCycle);
    }
}