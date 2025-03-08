using EventTicketSystem.Server.Models;
using EventTicketSystem.Server.Repository;

namespace EventTicketSystem.Server.Services
{
    public class TicketService: ITicketService
    {

        private readonly ITicketRepository _repository;
        private readonly IEventRepository _eventRepository;
        public TicketService(ITicketRepository repository, IEventRepository eventRepository)
        {
            _repository = repository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Ticket>> GetTickets() => await _repository.GetAllTickets();

        public async Task<Ticket?> GetTicketById(int id) => await _repository.GetTicketById(id);

        public async Task AddTicket(Ticket t)
        {

            var ticket = await _eventRepository.GetEventById(t.eventId);
            if ( ticket == null) {
                throw new ArgumentException("Dont exist that Event with that id");
            }
            if (ticket.availableSeats > 1)
            {

                ticket.availableSeats--;

                await _eventRepository.SaveChanges();
                await _repository.AddTicket(t);
                await _repository.SaveChanges();
            }


        }

        public async Task DeleteTicket(int id)
        {
            await _repository.DeleteTicket(id);
            await _repository.SaveChanges();
        }

    }
}
