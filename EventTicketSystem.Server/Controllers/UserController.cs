using EventTicketSystem.Server.Models;
using EventTicketSystem.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventTicketSystem.Server.Controllers
{
    public class UserController : Controller
    {

        private readonly ITicketService _ticketService;
        public UserController(ITicketService ticketService) { 
            
            _ticketService = ticketService;
        }


        [HttpGet("/{UserId}/tickets")]
        public async Task<ActionResult<Ticket>> GetTicketByUserId(int UserId)
        {
            // getAllTicketByUserId

            return Ok();
        }

    }
}
