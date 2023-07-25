using Metrics.Domain.Boundaries.ApplicationServices;
using Metrics.Domain.Boundaries.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Metrics.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase{
    private readonly ITeamService teamService;
    public TeamsController(ITeamService teamService) {
        this.teamService = teamService;
    }

    [HttpGet(Name = "")]
    public IEnumerable<TeamDto> Get() {
        return teamService.GetTeams();
    }

    [HttpGet(Name = "/{id:int}/cycle_time")]
    public TimeSpan CycleTime(int id) {
        return teamService.GetTeamCycleTime(id);
    }
}
