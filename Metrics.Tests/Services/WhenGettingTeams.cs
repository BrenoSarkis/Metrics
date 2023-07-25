using FluentAssertions;
using Metrics.Domain.Application.Services;
using Metrics.Tests.Helpers;
using Xunit;
using static Metrics.Tests.Helpers.TeamBuilder;

namespace Metrics.Tests.Services;

public class WhenGettingTeams{
    private TeamDataProviderMock teamDataProviderMock = new();
    private TeamRepositoryMock teamRepositoryMock = new();

    [Fact]
    public void Calls_TeamDataProvider() {
        var service = new TeamService(teamDataProviderMock, teamRepositoryMock);

        service.GetTeams();

        teamDataProviderMock.CalledGetTeams().Should().BeTrue();
    }

    [Fact]
    public void If_TeamDataProvider_Is_Unavailable_Uses_Internal_Storage() {
        var service = new TeamService(teamDataProviderMock, teamRepositoryMock);
        teamDataProviderMock.EnsureThatCallingGetTeamsWillCrash();
        teamRepositoryMock.Save(TeamA);

        var result = service.GetTeams();

        result.Count.Should().Be(1);
        result.First().Id.Should().Be(TeamA.Id);
        result.First().Name.Should().Be(TeamA.Name);
    }
}