using Metrics.Domain;

namespace Metrics.Tests.Helpers;

public class TeamBuilder
{
    public static Team TeamA = new(1, "Team A", BacklogBuilder.BacklogA);
    public static Team TeamB = new(2, "Team B", BacklogBuilder.BacklogB);
}

public class BacklogBuilder {
    public static Backlog BacklogA = new Backlog();
    public static Backlog BacklogB = new Backlog();
}

public class WorkItemBuilder {
    public static WorkItem WorkItemA = new(1, "WI A", new DateTime(2023, 7, 24, 12, 0, 0), new DateTime(2023, 7, 25, 0, 0, 0));
    public static WorkItem WorkItemB = new(2, "WI B", new DateTime(2023, 7, 23, 12, 0, 0), new DateTime(2023, 7, 24, 0, 0, 0));
}