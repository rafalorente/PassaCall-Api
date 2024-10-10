using Microsoft.AspNetCore.Mvc;
using PassaCall_Api.Dto.Map;
using PassaCall_Api.Models;
using PassaCall_Api.Services.Map;

namespace PassaCall_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMapInterface _mapInterface;

        public MapController(IMapInterface mapInterface)
        {
            _mapInterface = mapInterface;
        }


        [HttpGet("ListarMapas")]
        public async Task<ActionResult<ResponseModel<List<MapModel>>>> GetMaps()
        {
            var maps = await _mapInterface.GetMaps();
            return Ok(maps);
        }

        [HttpGet("BuscaMapaPorId/{idMap}")]
        public async Task<ActionResult<ResponseModel<MapModel>>> GetMapsById(int idMap)
        {
            var map = await _mapInterface.GetMapById(idMap);
            return Ok(map);
        }

        [HttpPost("CriarMapa")]
        public async Task<ActionResult<ResponseModel<List<MapModel>>>> CreateMap(MapCreateDto mapCreateDto)
        {
            var map = await _mapInterface.CreateMap(mapCreateDto);
            return Ok(map);
        }

        [HttpPut("EditarMapa")]
        public async Task<ActionResult<ResponseModel<List<MapModel>>>> UpdateMap(MapUpdateDto mapUpdateDto)
        {
            var map = await _mapInterface.UpdateMap(mapUpdateDto);

            return Ok(map);
        }

        [HttpDelete("RemoverMapa")]
        public async Task<ActionResult<ResponseModel<List<MapModel>>>> DeleteMap(int idMap)
        {
            var map = await _mapInterface.DeleteMap(idMap);

            return Ok(map);
        }
    }
}
