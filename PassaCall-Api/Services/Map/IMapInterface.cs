using PassaCall_Api.Dto.Event;
using PassaCall_Api.Dto.Map;
using PassaCall_Api.Models;

namespace PassaCall_Api.Services.Map
{
    public interface IMapInterface
    {
        Task<ResponseModel<List<MapModel>>> GetMaps();
        Task<ResponseModel<MapModel>> GetMapById(int idMap);
        Task<ResponseModel<List<MapModel>>> CreateMap(MapCreateDto maptCreateDto);
        Task<ResponseModel<List<MapModel>>> UpdateMap(MapUpdateDto mapUpdateDto);
        Task<ResponseModel<List<MapModel>>> DeleteMap(int idMap);
    }
}
