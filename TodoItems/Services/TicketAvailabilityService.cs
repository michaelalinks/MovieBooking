using TodoItems.Controllers;
using TodoItems.Data.Repositories;

namespace TodoItems.Services
{
    public class TicketAvailabilityService : ICrudService<TicketAvailabilityItem, int>
    {
        private readonly ICrudRepository<TicketAvailabilityItem, int> _ticketARepository;
        public TicketAvailabilityService(ICrudRepository<TicketAvailabilityItem, int> ticketARepository)
        {
            _ticketARepository = ticketARepository;
        }
        public void Add(TicketAvailabilityItem element)
        {
            _ticketARepository.Add(element);
            _ticketARepository.Save();
        }
        public void Delete(int id)
        {
            _ticketARepository.Delete(id);
            _ticketARepository.Save();
        }
        public TicketAvailabilityItem Get(int id)
        {
            return _ticketARepository.Get(id);
        }
        public IEnumerable<TicketAvailabilityItem> GetAll()
        {
            return _ticketARepository.GetAll();
        }
        public void Update(TicketAvailabilityItem old, TicketAvailabilityItem newT)
        {
            old.booking_date = newT.booking_date;
            old.seats = newT.seats;
            _ticketARepository.Update(old);
            _ticketARepository.Save();
        }
    }
}
