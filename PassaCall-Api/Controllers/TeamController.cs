using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassaCall_Api.Dto.Team;
using PassaCall_Api.Models;
using PassaCall_Api.Services.Team;

namespace PassaCall_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamInterface;

        public TeamController(ITeamService teaminteface)
        {
            _teamInterface = teaminteface;
        }

        [HttpGet("ListarTimes")]
        public async Task<ActionResult<ResponseModel<List<TeamModel>>>> GetTeams()
        {
            var teams = await _teamInterface.GetTeams();
            return Ok(teams);
        }

        [HttpGet("BuscaTimePorId/{idTeam}")]
        public async Task<ActionResult<ResponseModel<TeamModel>>> GetTeamById(int idTeam)
        {
            var team = await _teamInterface.GetTeamById(idTeam);
            return Ok(team);
        }

        [HttpPost("CriarTime")]
        public async Task<ActionResult<ResponseModel<List<TeamModel>>>> CreateTeam(TeamCreateDto teamCreateDto)
        {
            var team = await _teamInterface.CreateTeam(teamCreateDto);
            return Ok(team);
        }

        [HttpPut("EditarTime")]
        public async Task<ActionResult<ResponseModel<List<TeamModel>>>> UpdateTeam(TeamUpdateDto teamUpdateDto)
        {
            var team = await _teamInterface.UpdateTeam(teamUpdateDto);
            return Ok(team);
        }

        [HttpDelete("RemoverTime")]
        public async Task<ActionResult<ResponseModel<List<TeamModel>>>> DeleteTeam(int idTeam)
        {
            var team = await _teamInterface.DeleteTeam(idTeam);
            return Ok(team);
        }
    }
}
