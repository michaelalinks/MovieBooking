using TodoItems.Controllers;

namespace TodoItems.Data.Repositories
{
    public class TicketAvailabilityRepository : ICrudRepository<TicketAvailabilityItem, int>
    {

        private readonly TodoContext _ticketAContext;
        public TicketAvailabilityRepository(TodoContext ticketAContext)
        {
            _ticketAContext = ticketAContext ?? throw new
            ArgumentNullException(nameof(ticketAContext));
        }
        public void Add(TicketAvailabilityItem element)
        {
            _ticketAContext.AvailabilityItems.Add(element);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _ticketAContext.AvailabilityItems.Remove(Get(id));
        }

        public bool Exists(int id)
        {
            return _ticketAContext.AvailabilityItems.Any(u => u.Id == id);
        }

        public TicketAvailabilityItem Get(int id)
        {
            return _ticketAContext.AvailabilityItems.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<TicketAvailabilityItem> GetAll()
        {
            return _ticketAContext.AvailabilityItems.ToList();
        }

        public bool Save()
        {
            return _ticketAContext.SaveChanges() > 0;
        }

        public void Update(TicketAvailabilityItem element)
        {
            _ticketAContext.Update(element);
        }
    }
}
