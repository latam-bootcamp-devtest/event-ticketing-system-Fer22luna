using EventTicketSystem.Server.Data;
using EventTicketSystem.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventTicketSystem.Server.Repository
{
    public class TicketRepository: ITicketRepository
    {

        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets() => await _context.Tickets.ToListAsync();

        public async Task<Ticket?> GetTicketById(int id) => await _context.Tickets.FindAsync(id);

        public async Task<IEnumerable<Ticket>> GetTickesByUserId(int userId) => await _context.Tickets.Where(c => c.Equals(userId)).ToListAsync();

        public async Task AddTicket(Ticket t)
        {
            await _context.Tickets.AddAsync(t);
        }

        public async Task DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
        }

        public async Task SaveChanges() => await _context.SaveChangesAsync();

    }
}

