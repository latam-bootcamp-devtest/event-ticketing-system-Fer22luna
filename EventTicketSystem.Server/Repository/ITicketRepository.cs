using EventTicketSystem.Server.Models;

namespace EventTicketSystem.Server.Repository
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<Ticket?> GetTicketById(int id);
        Task AddTicket(Ticket e);
        Task DeleteTicket(int id);
        Task SaveChanges();
    }
}
