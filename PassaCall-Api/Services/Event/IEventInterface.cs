using PassaCall_Api.Models;

namespace PassaCall_Api.Services.Event
{
    public interface IEventInterface
    {
        Task<ResponseModel<List<EventModel>>> GetEvent();
        Task<ResponseModel<EventModel>> GetEventById( int idEvent);
    }
}
