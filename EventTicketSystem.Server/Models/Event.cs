namespace EventTicketSystem.Server.Models
{
    public class Event
    {

        public int eventId { get; set; }
        public string? name { get; set; }
        public DateTime date { get; set; }
        public int availableSeats { get; set; }


        public Event()
        {
            eventId = 0;
            name = string.Empty;
            date = DateTime.Now;
            availableSeats = 0;
        }

    }
}
