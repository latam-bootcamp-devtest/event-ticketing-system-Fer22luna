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

        public TicketController(ITicketService service)
        {
            _service = service;
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
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }


        [HttpPost]
        public async Task<ActionResult> AddTicket(Ticket t)
        {
            await _service.AddTicket(t);
            return CreatedAtAction(nameof(GetTicketById), new { id = t.ticketId }, t);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTicket(int id)
        {
            await _service.DeleteTicket(id);
            return NoContent();
        }

    }
}
