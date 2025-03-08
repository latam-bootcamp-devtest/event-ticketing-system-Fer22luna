using EventTicketSystem.Server.Models;
using EventTicketSystem.Server.Repository;

namespace EventTicketSystem.Server.Services
{
    public class EventService
    {

        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Event>> GetEvent() => await _repository.GetAllEvents();

        public async Task<Event?> GetEventById(int id) => await _repository.GetEventById( id);

        public async Task AddEvent(Event e)
        {
            await _repository.AddEvent(e);
            await _repository.SaveChanges();
        }

        public async Task DeleteEvent(int id)
        {
            await _repository.DeleteEvent(id);
            await _repository.SaveChanges();
        }

    }
}
