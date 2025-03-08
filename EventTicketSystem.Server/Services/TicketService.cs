using EventTicketSystem.Server.Models;
using EventTicketSystem.Server.Repository;

namespace EventTicketSystem.Server.Services
{
    public class TicketService: ITicketService
    {

        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Ticket>> GetTickets() => await _repository.GetAllTickets();

        public async Task<Ticket?> GetTicketById(int id) => await _repository.GetTicketById(id);

        public async Task AddTicket(Ticket t)
        {

            await _repository.AddTicket(t);
            await _repository.SaveChanges();
        }

        public async Task DeleteTicket(int id)
        {
            await _repository.DeleteTicket(id);
            await _repository.SaveChanges();
        }

    }
}
