using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassaCall_Api.Dto.Event;
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

        //Criando endpoint de listar eventos
        [HttpGet("ListarEventos")]
        public async Task<ActionResult<ResponseModel<List<EventModel>>>> GetEvent()
        {
            var events = await _eventInterface.GetEvent();
            return Ok(events);
        }

        [HttpGet("BuscaEventoPorId/{idEvent}")]
        public async Task<ActionResult<ResponseModel<EventModel>>> GetEventById(int idEvent)
        {
            var events = await _eventInterface.GetEventById(idEvent);
            return Ok(events);
        }

        [HttpPost("CriarEvento")]
        public async Task<ActionResult<ResponseModel<EventModel>>> CreateEvent(EventCreateDto eventCreateDto)
        {
           var events = await _eventInterface.CreateEvent(eventCreateDto);
            return Ok(events);
        }
    }
}
