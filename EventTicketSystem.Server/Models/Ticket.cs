using System.ComponentModel.DataAnnotations.Schema;

namespace EventTicketSystem.Server.Models
{
    public class Ticket
    {   
        public int ticketId {  get; set; }
        public int userId { get; set; }
        public int eventId { get; set; }

        public Ticket()
        {
            ticketId = 0;
            userId = 0;
            eventId = 0;
        }

    }
}
