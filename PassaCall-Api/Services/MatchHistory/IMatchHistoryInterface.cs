using PassaCall_Api.Dto.MatchHistory;
using PassaCall_Api.Models;

namespace PassaCall_Api.Services.MatchHistory
{
    public interface IMatchHistoryInterface
    {
        Task<ResponseModel<List<MatchHistoryModel>>> GetMatchHistory();
        Task<ResponseModel<MatchHistoryModel>> GetMatchHistoryById(int idMatchHistory);
        Task<ResponseModel<List<MatchHistoryModel>>> CreateMatchHistory(MatchHistoryCreateDto matchHistorytCreateDto);
        Task<ResponseModel<List<MatchHistoryModel>>> UpdateMatchHistory(MatchHistoryUpdateDto matchHistoryUpdateDto);
        Task<ResponseModel<List<MatchHistoryModel>>> DeleteMatchHistory(int idMatchHistory);
    }
}
