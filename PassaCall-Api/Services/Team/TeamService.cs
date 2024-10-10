using Microsoft.EntityFrameworkCore;
using PassaCall_Api.Data;
using PassaCall_Api.Dto.Team;
using PassaCall_Api.Models;

namespace PassaCall_Api.Services.Team
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _context;

        public TeamService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<TeamModel>>> GetTeams()
        {
            ResponseModel<List<TeamModel>> response = new ResponseModel<List<TeamModel>>();
            try
            {
                var teams = await _context.Team.ToListAsync();

                response.Data = teams;
                response.Message = "Todos os Times foram listados.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<TeamModel>> GetTeamById(int idTeam)
        {
            ResponseModel<TeamModel> response = new ResponseModel<TeamModel>();

            try
            {
                var team = await _context.Team.FirstOrDefaultAsync(teamDatabase => teamDatabase.IdTeam == idTeam);

                if (team == null)
                {
                    response.Message = "Nenhum Time localizado! ";
                }

                response.Data = team;
                response.Message = "Time Localizado!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TeamModel>>> CreateTeam(TeamCreateDto teamCreateDto)
        {
            ResponseModel<List<TeamModel>> response = new ResponseModel<List<TeamModel>>();

            try
            {
                var team = new TeamModel()
                {
                    NameTeam = teamCreateDto.NameTeam,
                };

                _context.Add(team);
                await _context.SaveChangesAsync();

                response.Data = await _context.Team.ToListAsync();
                response.Message = "Time criado com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TeamModel>>> UpdateTeam(TeamUpdateDto teamUpdateDto)
        {
            ResponseModel<List<TeamModel>> response = new ResponseModel<List<TeamModel>>();

            try
            {
                var team = await _context.Team.FirstOrDefaultAsync(teamDatabase => teamDatabase.IdTeam == teamUpdateDto.IdTeam);

                if (team == null)
                {
                    response.Message = "Nenhum Time Localizado";
                    return response;
                }

                team.NameTeam = teamUpdateDto.NameTeam;

                _context.Update(team);
                await _context.SaveChangesAsync();

                response.Data = await _context.Team.ToListAsync();
                response.Message = "Dados Editados com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TeamModel>>> DeleteTeam(int idTeam)
        {
            ResponseModel<List<TeamModel>> response = new ResponseModel<List<TeamModel>>();

            try
            {
                var team = await _context.Team.FirstOrDefaultAsync(teamDatabase => teamDatabase.IdTeam == idTeam);

                if (team == null)
                {
                    response.Message = "Nenhum Time Localizado";
                    return response;
                }

                _context.Remove(team);
                await _context.SaveChangesAsync();

                response.Data = await _context.Team.ToListAsync();

                response.Message = "Time Removido com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }
    }
}
