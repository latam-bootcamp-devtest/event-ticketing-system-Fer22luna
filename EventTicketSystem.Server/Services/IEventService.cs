using EventTicketSystem.Server.Models;

namespace EventTicketSystem.Server.Services
{
    public interface IEventService
    {

        Task<IEnumerable<Event>> GetEvents();
        Task<Event?> GetEventById(int id);
        Task AddEvent(Event e);
        Task DeleteEvent(int id);
    }
}
