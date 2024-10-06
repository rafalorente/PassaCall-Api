using Microsoft.EntityFrameworkCore;
using PassaCall_Api.Data;
using PassaCall_Api.Models;

namespace PassaCall_Api.Services.Event
{
    public class EventService : IEventInterface
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<EventModel>>> GetEvent()
        {
            ResponseModel<List<EventModel>> response = new ResponseModel<List<EventModel>>();
            try
            {
                var events = await _context.Event.ToListAsync();

                response.Data = events;
                response.Message = "Todos os eventos foram listados.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }

        public Task<ResponseModel<EventModel>> GetEventById(int idEvent)
        {
            throw new NotImplementedException();
        }
    }
}
