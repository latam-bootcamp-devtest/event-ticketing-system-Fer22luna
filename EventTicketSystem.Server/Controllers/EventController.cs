using EventTicketSystem.Server.Services;
using Microsoft.AspNetCore.Mvc;
using EventTicketSystem.Server.Models;

namespace EventTicketSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventController : Controller
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            var events = await _service.GetEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            var events = await _service.GetEventById(id);
            if (events == null) return NotFound();
            return Ok(events);
        }


        [HttpPost]
        public async Task<ActionResult> AddEvent(Event e)
        {
            if(e.availableSeats <= 0)
            {
                return BadRequest("Available Seats must be greater than 0");
            }
            await _service.AddEvent(e);
            return CreatedAtAction(nameof(GetEventById), new { id = e.eventId }, e);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            await _service.DeleteEvent(id);
            return NoContent();
        }



    }
}
