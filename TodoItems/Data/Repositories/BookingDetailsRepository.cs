using TodoItems.Controllers;

namespace TodoItems.Data.Repositories
{
    public class BookingDetailsRepository : ICrudRepository<BookingDetailsItem, int>
    {

        private readonly TodoContext _bookingContext;
        public BookingDetailsRepository(TodoContext bookingContext)
        {
            _bookingContext = bookingContext ?? throw new
            ArgumentNullException(nameof(bookingContext));
        }
        public void Add(BookingDetailsItem element)
        {
            _bookingContext.BookingItems.Add(element);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _bookingContext.BookingItems.Remove(Get(id));
        }

        public bool Exists(int id)
        {
            return _bookingContext.BookingItems.Any(u => u.Id == id);
        }

        public BookingDetailsItem Get(int id)
        {
            return _bookingContext.BookingItems.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<BookingDetailsItem> GetAll()
        {
            return _bookingContext.BookingItems.ToList();
        }

        public bool Save()
        {
            return _bookingContext.SaveChanges() > 0;
        }

        public void Update(BookingDetailsItem element)
        {
            _bookingContext.Update(element);
        }
    }
}
