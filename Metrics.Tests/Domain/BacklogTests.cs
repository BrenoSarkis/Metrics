using FluentAssertions;
using Metrics.Domain;
using Xunit;

namespace Metrics.Tests.Domain;

public class BacklogTests
{
    [Fact]
    public void Cycle_Time_Should_Be_Zero_If_Theres_No_Work_Items()
    {
        var expectedAverageCycleTime = TimeSpan.Zero;

        var backLog = new Backlog();
        var averageCycleTime = backLog.CalculateAverageLifeCycle();

        averageCycleTime.Should().Be(expectedAverageCycleTime);
    }

    [Fact]
    public void Calculates_Average_Cycle_Time_From_Work_Items()
    {
        var markedAsInProgress = new DateTime(2023, 7, 24, 12, 0, 0);
        var markedAsDone = new DateTime(2023, 7, 25, 12, 0, 0);
        var firstWorkItem = new WorkItem(1, "First WI", markedAsInProgress, markedAsDone);
        var secondWorkItem = new WorkItem(2, "Second WI", markedAsInProgress, markedAsDone);
        var expectedAverageCycleTime = TimeSpan.FromHours(24);

        var backLog = new Backlog();
        backLog.AddWorkItems(firstWorkItem, secondWorkItem);
        var averageCycleTime = backLog.CalculateAverageLifeCycle();

        averageCycleTime.Should().Be(expectedAverageCycleTime);
    }
}