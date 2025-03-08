using EventTicketSystem.Server.Models;

namespace EventTicketSystem.Server.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event?> GetEventById(int id);
        Task AddEvent(Event e);
        Task DeleteEvent(int id);
        Task SaveChanges();
    }
}
