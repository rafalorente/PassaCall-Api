using PassaCall_Api.Dto.Team;
using PassaCall_Api.Models;

namespace PassaCall_Api.Services.Team
{
    public interface ITeamService
    {
        Task<ResponseModel<List<TeamModel>>> GetTeams();
        Task<ResponseModel<TeamModel>> GetTeamById(int idTeam);
        Task<ResponseModel<List<TeamModel>>> CreateTeam(TeamCreateDto teamCreateDto);
        Task<ResponseModel<List<TeamModel>>> UpdateTeam(TeamUpdateDto teamUpdateDto);
        Task<ResponseModel<List<TeamModel>>> DeleteTeam(int idTeam);
    }
}
