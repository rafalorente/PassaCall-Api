using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassaCall_Api.Models;
using PassaCall_Api.Services.Event;

namespace PassaCall_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventInterface _eventInterface;

        public EventController(IEventInterface eventInterface)
        {
            _eventInterface = eventInterface;
        }

        //Criando endpoint de eventos
        [HttpGet("ListarEventos")]
        public async Task<ActionResult<ResponseModel<List<EventModel>>>> GetEvent()
        {
            var events = await _eventInterface.GetEvent();
            return Ok(events);
        }
    }
}
