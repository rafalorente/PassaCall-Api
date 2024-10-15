using Microsoft.EntityFrameworkCore;
using PassaCall_Api.Data;
using PassaCall_Api.Dto.Map;
using PassaCall_Api.Dto.MatchHistory;
using PassaCall_Api.Models;
using System;

namespace PassaCall_Api.Services.MatchHistory
{
    public class MatchHistoryService : IMatchHistoryInterface
    {
        private readonly AppDbContext _context;

        public MatchHistoryService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<MatchHistoryModel>>> GetMatchHistory()
        {
            ResponseModel<List<MatchHistoryModel>> response = new ResponseModel<List<MatchHistoryModel>>();

            try
            {
                var matchHistory = await _context.MatchHistory.ToListAsync();

                response.Data = matchHistory;
                response.Message = "Todos os históricos das partidas foram listados.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<MatchHistoryModel>> GetMatchHistoryById(int idMatchHistory)
        {
            ResponseModel<MatchHistoryModel> response = new ResponseModel<MatchHistoryModel>();

            try
            {
                var matchHistory = await _context.MatchHistory.FirstOrDefaultAsync(matchHistoryDatabase => matchHistoryDatabase.IdMatchHistory == idMatchHistory);

                if (matchHistory == null)
                {
                    response.Message = "Nenhum histórico localizado! ";
                }

                response.Data = matchHistory;
                response.Message = "Partida Localizada!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<MatchHistoryModel>>> CreateMatchHistory(MatchHistoryCreateDto matchHistorytCreateDto)
        {
            ResponseModel<List<MatchHistoryModel>> response = new ResponseModel<List<MatchHistoryModel>>();

            try
            {
                var matchHistory = new MatchHistoryModel()
                {
                    Team = matchHistorytCreateDto.Team,
                    Map = matchHistorytCreateDto.Map,
                    WinTwoRounds = matchHistorytCreateDto.WinTwoRounds,
                    WinRoundPistolCt = matchHistorytCreateDto.WinRoundPistolCt,
                    WinRoundPistolTr = matchHistorytCreateDto.WinRoundPistolTr,
                    CtHalf = matchHistorytCreateDto.CtHalf,
                    TrHalf = matchHistorytCreateDto.TrHalf,
                    OverTime = matchHistorytCreateDto.OverTime,
                    MatchDate = matchHistorytCreateDto.MatchDate,
                    Event = matchHistorytCreateDto.Event,
                    MapPick = matchHistorytCreateDto.MapPick
                };

                _context.Add(matchHistory);
                await _context.SaveChangesAsync();

                response.Data = await _context.MatchHistory.ToListAsync();
                response.Message = "Historico de partida criado com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<MatchHistoryModel>>> UpdateMatchHistory(MatchHistoryUpdateDto matchHistoryUpdateDto)
        {
            ResponseModel<List<MatchHistoryModel>> response = new ResponseModel<List<MatchHistoryModel>>();

            try
            {
                var matchHistory = await _context.MatchHistory.FirstOrDefaultAsync(matchHistoryDatabase => matchHistoryDatabase.IdMatchHistory == matchHistoryUpdateDto.IdMatchHistory);

                if (matchHistory == null)
                {
                    response.Message = "Nenhum Histórico Localizado";
                    return response;
                }

                matchHistory.Team = matchHistoryUpdateDto.Team;
                matchHistory.Map = matchHistoryUpdateDto.Map;
                matchHistory.WinTwoRounds = matchHistoryUpdateDto.WinTwoRounds;
                matchHistory.WinRoundPistolCt = matchHistoryUpdateDto.WinRoundPistolCt;
                matchHistory.WinRoundPistolTr = matchHistoryUpdateDto.WinRoundPistolTr;
                matchHistory.CtHalf = matchHistoryUpdateDto.CtHalf;
                matchHistory.TrHalf = matchHistoryUpdateDto.TrHalf;
                matchHistory.OverTime = matchHistoryUpdateDto.OverTime;
                matchHistory.MatchDate = matchHistoryUpdateDto.MatchDate;
                matchHistory.Event = matchHistoryUpdateDto.Event;
                matchHistory.MapPick = matchHistoryUpdateDto.MapPick;

                _context.Update(matchHistory);
                await _context.SaveChangesAsync();

                response.Data = await _context.MatchHistory.ToListAsync();
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

        public async Task<ResponseModel<List<MatchHistoryModel>>> DeleteMatchHistory(int idMatchHistory)
        {
            ResponseModel<List<MatchHistoryModel>> response = new ResponseModel<List<MatchHistoryModel>>();

            try
            {
                var matchHistory = await _context.MatchHistory.FirstOrDefaultAsync(matchHistoryDatabase => matchHistoryDatabase.IdMatchHistory == idMatchHistory);

                if (matchHistory == null)
                {
                    response.Message = "Nenhum Histórico Localizado";
                    return response;
                }

                _context.Remove(matchHistory);
                await _context.SaveChangesAsync();

                response.Data = await _context.MatchHistory.ToListAsync();

                response.Message = "Histórico Removido com sucesso!";

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
