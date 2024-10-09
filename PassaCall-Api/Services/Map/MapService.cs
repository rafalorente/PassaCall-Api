using Microsoft.EntityFrameworkCore;
using PassaCall_Api.Data;
using PassaCall_Api.Dto.Event;
using PassaCall_Api.Dto.Map;
using PassaCall_Api.Models;

namespace PassaCall_Api.Services.Map
{
    public class MapService : IMapInterface
    {
        private readonly AppDbContext _context;

        public MapService(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<ResponseModel<List<MapModel>>> GetMaps()
        {
            ResponseModel<List<MapModel>> response = new ResponseModel<List<MapModel>>();
            try
            {
                var maps = await _context.Map.ToListAsync();

                response.Data = maps;
                response.Message = "Todos os mapas foram listados.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<MapModel>> GetMapById(int idMap)
        {
            ResponseModel<MapModel> response = new ResponseModel<MapModel>();

            try
            {
                var map = await _context.Map.FirstOrDefaultAsync(mapDatabase => mapDatabase.IdMap == idMap);

                if (map == null)
                {
                    response.Message = "Nenhum Mapa localizado! ";
                }

                response.Data = map;
                response.Message = "Mapa Localizado!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<MapModel>>> CreateMap(MapCreateDto maptCreateDto)
        {
            ResponseModel<List<MapModel>> response = new ResponseModel<List<MapModel>>();

            try
            {
                var map = new MapModel()
                {
                    MapName = maptCreateDto.MapName,
                };

                _context.Add(map);
                await _context.SaveChangesAsync();

                response.Data = await _context.Map.ToListAsync();
                response.Message = "Mapa criado com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<MapModel>>> UpdateMap(MapUpdateDto mapUpdateDto)
        {
            ResponseModel<List<MapModel>> response = new ResponseModel<List<MapModel>>();

            try
            {
                var map = await _context.Map.FirstOrDefaultAsync(mapDatabase => mapDatabase.IdMap == mapUpdateDto.IdMap);

                if (map == null)
                {
                    response.Message = "Nenhum Mapa Localizado";
                    return response;
                }

                map.MapName = mapUpdateDto.MapName;

                _context.Update(map);
                await _context.SaveChangesAsync();

                response.Data = await _context.Map.ToListAsync();
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

        public async Task<ResponseModel<List<MapModel>>> DeleteMap(int idMap)
        {
            ResponseModel<List<MapModel>> response = new ResponseModel<List<MapModel>>();

            try
            {
                var map = await _context.Map.FirstOrDefaultAsync(mapDatabase => mapDatabase.IdMap == idMap);

                if (map == null)
                {
                    response.Message = "Nenhum Mapa Localizado";
                    return response;
                }

                _context.Remove(map);
                await _context.SaveChangesAsync();

                response.Data = await _context.Map.ToListAsync();

                response.Message = "Mapa Removido com sucesso!";

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
