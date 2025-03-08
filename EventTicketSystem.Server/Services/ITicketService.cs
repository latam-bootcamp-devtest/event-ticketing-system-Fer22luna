using EventTicketSystem.Server.Models;

namespace EventTicketSystem.Server.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTickets();
        Task<Ticket?> GetTicketById(int id);
        Task AddTicket(Ticket t);
        Task DeleteTicket(int id);
    }
}
