using EventTicketSystem.Server.Models;
using EventTicketSystem.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventTicketSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TicketController : Controller
    {
        private readonly ITicketService _service;
        private readonly IEventService _eventService;

        public TicketController(ITicketService service, IEventService eventService)
        {
            _service = service;
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAllTickets()
        {
            var tickets = await _service.GetTickets();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int id)
        {
            var ticket = await _service.GetTicketById(id);
            if (ticket is null) return NotFound();
            return Ok(ticket);
        }


        [HttpPost]
        public async Task<ActionResult> AddTicket(Ticket t)
        {
            var eventSelected = await _eventService.GetEventById(t.eventId);
            if (eventSelected is null) return NotFound("The event dosen't exist !");
            if(eventSelected.availableSeats > 1)
            {
                eventSelected.availableSeats--;
                // save the event with Update
                return Conflict();         
                    }


            await _service.AddTicket(t);
            return CreatedAtAction(nameof(GetTicketById), new { id = t.ticketId }, t);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTicket(int id)
        {

            var ticketSelected = await _service.GetTicketById(id);
            if (ticketSelected is null) return NotFound();

            var eventSelected = await _eventService.GetEventById(ticketSelected.eventId);
            // if (DateTime.Compare(eventSelected.date,DateTime.Now) ) return BadRequest();
            if (eventSelected.date < DateTime.Now) return BadRequest();

            await _service.DeleteTicket(id);

            eventSelected.availableSeats++;
            // save the event with update

            return NoContent();
        }

    }
}
