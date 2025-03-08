using EventTicketSystem.Server.Models;
using EventTicketSystem.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace EventTicketSystem.Server.Repository
{
    public class EventRepository:IEventRepository
    {

        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents() => await _context.Events.ToListAsync();

        public async Task<Event?> GetEventById(int id) => await _context.Events.FindAsync(id);

        public async Task AddEvent(Event e)
        {
            await _context.Events.AddAsync(e);
        }

        public async Task DeleteEvent(int id)
        {
            var employe = await _context.Events.FindAsync(id);
            if (employe != null)
            {
                _context.Events.Remove(employe);
            }
        }

        public async Task SaveChanges() => await _context.SaveChangesAsync();

    }
}
