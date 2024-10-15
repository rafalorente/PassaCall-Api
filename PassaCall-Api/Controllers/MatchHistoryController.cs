using Microsoft.AspNetCore.Mvc;
using PassaCall_Api.Dto.MatchHistory;
using PassaCall_Api.Models;
using PassaCall_Api.Services.MatchHistory;

namespace PassaCall_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MatchHistoryController : ControllerBase
    {
       private readonly IMatchHistoryInterface _matchHistoryInterface;

        public MatchHistoryController(IMatchHistoryInterface matchHistoryInterface)
        {
            _matchHistoryInterface = matchHistoryInterface;
        }

        [HttpGet("ListarHistoricoPartidas")]
        public async Task<ActionResult<ResponseModel<List<MatchHistoryModel>>>> GetMatchHistory()
        {
            var matchHistory = await _matchHistoryInterface.GetMatchHistory();

            return Ok(matchHistory);
        }

        [HttpGet("ListarHistoricoPartidaPorId/{idMatchHistory}")]
        public async Task<ActionResult<ResponseModel<MatchHistoryModel>>> GetMatchHistoryById(int idMatchHistory)
        {
            var matchHistory = await GetMatchHistoryById(idMatchHistory);

            return Ok(matchHistory);
        }

        [HttpPost("CriarHistoricoPartida")]
        public async Task<ActionResult<ResponseModel<List<MatchHistoryModel>>>> CreateMatchHistory(MatchHistoryCreateDto matchHistoryCreateDto)
        {
            var matchHistory = await CreateMatchHistory(matchHistoryCreateDto);

            return Ok(matchHistory);
        }

        [HttpPut("EditarHistoricoPartida")]
        public async Task<ActionResult<ResponseModel<List<MatchHistoryModel>>>> UpdateMatchHistory(MatchHistoryUpdateDto matchHistoryUpdateDto)
        {
            var matchHistory = await UpdateMatchHistory(matchHistoryUpdateDto);

            return Ok(matchHistory);
        }

        [HttpDelete("RemoverMapa/{idMatchHistory}")]
        public async Task<ActionResult<ResponseModel<List<MatchHistoryModel>>>> DeleteMatchHistory(int idMatchHistory)
        {
            var matchHistory = await DeleteMatchHistory(idMatchHistory);

            return Ok(matchHistory);
        }

    }
}
