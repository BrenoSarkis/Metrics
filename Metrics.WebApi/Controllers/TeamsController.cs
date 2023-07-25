using Metrics.Domain.Boundaries.ApplicationServices;
using Metrics.Domain.Boundaries.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Metrics.WebApi.Controllers;
[ApiController]
public class TeamsController : ControllerBase{
    private readonly ITeamService teamService;
    public TeamsController(ITeamService teamService) {
        this.teamService = teamService;
    }

    [HttpGet]
    [Route("teams/")]
    public IEnumerable<TeamDto> GetTeams() {
        return teamService.GetTeams();
    }

    [HttpGet]
    [Route("teams/{id:int}/cycle_time")]
    public TimeSpan CycleTime(int id) {
        return teamService.GetTeamCycleTime(id);
    }

    [HttpPost]
    [Route("teams/synchronize")]
    public void Synchronize() {
        teamService.Synchronize();
    }
}
