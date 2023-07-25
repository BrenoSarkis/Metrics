using FluentAssertions;
using Metrics.Domain.Application.Services;
using Metrics.Tests.Helpers;
using Xunit;

namespace Metrics.Tests.Services;

public class WhenSynchronizingTeams {
    private TeamDataProviderMock teamDataProviderMock = new();
    private TeamRepositoryMock teamRepositoryMock = new();

    [Fact]
    public void Does_Nothing_If_There_Are_No_Teams() {
        var service = new TeamService(teamDataProviderMock, teamRepositoryMock);

        service.Synchronize();

        teamDataProviderMock.GetTeams().Should().BeEmpty();
        teamRepositoryMock.GetTeams().Should().BeEmpty();
    }

    [Fact]
    public void Does_Nothing_If_Already_In_Sync() {
        teamDataProviderMock.AssumeExistingTeams(TeamDtoBuilder.TeamA);
        teamRepositoryMock.Save(TeamBuilder.TeamA);

        var service = new TeamService(teamDataProviderMock, teamRepositoryMock);

        service.Synchronize();

        teamDataProviderMock.GetTeams().Count().Should().Be(1);
        teamRepositoryMock.GetTeams().Count().Should().Be(1);
    }

    [Fact]
    public void Feeds_Local_Storage_From_TeamDataProvider() {
        teamDataProviderMock.AssumeExistingTeams(TeamDtoBuilder.TeamA);

        var service = new TeamService(teamDataProviderMock, teamRepositoryMock);

        service.Synchronize();

        var teamsOnDataProvider = teamDataProviderMock.GetTeams();
        teamsOnDataProvider.Count.Should().Be(1);
        teamsOnDataProvider.First().Id.Should().Be(TeamDtoBuilder.TeamA.Id);
        teamsOnDataProvider.First().Name.Should().Be(TeamDtoBuilder.TeamA.Name);

        var teamsOnLocalStorage = teamRepositoryMock.GetTeams();
        teamsOnLocalStorage.Count.Should().Be(1);
        teamsOnLocalStorage.First().Id.Should().Be(TeamBuilder.TeamA.Id);
        teamsOnLocalStorage.First().Name.Should().Be(TeamBuilder.TeamA.Name);
    }

    [Fact]
    public void Syncs_Missing_Teams() {
        teamDataProviderMock.AssumeExistingTeams(TeamDtoBuilder.TeamA);
        teamDataProviderMock.AssumeExistingTeams(TeamDtoBuilder.TeamB);
        teamRepositoryMock.Save(TeamBuilder.TeamA);

        var service = new TeamService(teamDataProviderMock, teamRepositoryMock);

        service.Synchronize();

        var teamsOnDataProvider = teamDataProviderMock.GetTeams();
        teamsOnDataProvider.Count.Should().Be(2);
        teamsOnDataProvider[0].Id.Should().Be(TeamDtoBuilder.TeamA.Id);
        teamsOnDataProvider[0].Name.Should().Be(TeamDtoBuilder.TeamA.Name);
        teamsOnDataProvider[1].Id.Should().Be(TeamDtoBuilder.TeamB.Id);
        teamsOnDataProvider[1].Name.Should().Be(TeamDtoBuilder.TeamB.Name);

        var teamsOnLocalStorage = teamRepositoryMock.GetTeams();
        teamsOnLocalStorage.Count.Should().Be(2);
        teamsOnLocalStorage[0].Id.Should().Be(TeamBuilder.TeamA.Id);
        teamsOnLocalStorage[0].Name.Should().Be(TeamBuilder.TeamA.Name);
        teamsOnLocalStorage[1].Id.Should().Be(TeamBuilder.TeamB.Id);
        teamsOnLocalStorage[1].Name.Should().Be(TeamBuilder.TeamB.Name);
    }
}