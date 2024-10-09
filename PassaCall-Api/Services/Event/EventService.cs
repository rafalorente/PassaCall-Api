using Microsoft.EntityFrameworkCore;
using PassaCall_Api.Data;
using PassaCall_Api.Dto.Event;
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
        public async Task<ResponseModel<EventModel>> GetEventById(int idEvent)
        {
            ResponseModel<EventModel> response = new ResponseModel<EventModel>();

            try
            {
                var events = await _context.Event.FirstOrDefaultAsync(eventDatabase => eventDatabase.IdEvent == idEvent);

                if (events == null)
                {
                    response.Message = "Nenhum evento localizado! ";
                }

                response.Data = events;
                response.Message = "Evento Localizado!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<EventModel>>> CreateEvent(EventCreateDto eventCreateDto)
        {
            ResponseModel<List<EventModel>> response = new ResponseModel<List<EventModel>>();

            try
            {

                var events = new EventModel()
                {
                    NameEvent = eventCreateDto.NameEvent,
                    InitialDate = eventCreateDto.InitialDate,
                    FinalDate = eventCreateDto.FinalDate,
                };

                _context.Add(events);
                await _context.SaveChangesAsync();

                response.Data = await _context.Event.ToListAsync();
                response.Message = "Evento criado com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Stats = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<EventModel>>> UpdateEvent(EventUpdateDto eventUpdateDto)
        {
            ResponseModel<List<EventModel>> response = new ResponseModel<List<EventModel>>();

            try
            {

                var events = await _context.Event.FirstOrDefaultAsync(eventBanco => eventBanco.IdEvent == eventUpdateDto.IdEvent);

                if (events == null)
                {
                    response.Message = "Nenhum Evento Localizado";
                    return response;
                }

                events.NameEvent = eventUpdateDto.NameEvent;
                events.FinalDate = Convert.ToDateTime(eventUpdateDto.FinalDate);
                events.InitialDate = Convert.ToDateTime(eventUpdateDto.InitialDate);

                _context.Update(events);
                await _context.SaveChangesAsync();

                response.Data = await _context.Event.ToListAsync();
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
        public async Task<ResponseModel<List<EventModel>>> DeleteEvent(int idEvent)
        {
            ResponseModel<List<EventModel>> response = new ResponseModel<List<EventModel>>();

            try
            {
                var events = await _context.Event.FirstOrDefaultAsync(eventBanco => eventBanco.IdEvent == idEvent);

                if (events == null)
                {
                    response.Message = "Nenhum Evento Localizado";
                    return response;
                }

                _context.Remove(events);
                await _context.SaveChangesAsync();

                response.Data = await _context.Event.ToListAsync();

                response.Message = "Evento Removido com sucesso!";

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
