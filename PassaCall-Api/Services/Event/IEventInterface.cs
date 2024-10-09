using PassaCall_Api.Dto.Event;
using PassaCall_Api.Models;

namespace PassaCall_Api.Services.Event
{
    public interface IEventInterface
    {
        Task<ResponseModel<List<EventModel>>> GetEvent();
        Task<ResponseModel<EventModel>> GetEventById( int idEvent);
        Task<ResponseModel<List<EventModel>>> CreateEvent(EventCreateDto eventCreateDto);
        Task<ResponseModel<List<EventModel>>> UpdateEvent(EventUpdateDto eventUpdateDto);
        Task<ResponseModel<List<EventModel>>> DeleteEvent(int idEvent);


    }
}
