using TodoItems.Controllers;
using TodoItems.Data.Repositories;

namespace TodoItems.Services
{
    public class BookingDetailsService : ICrudService<BookingDetailsItem, int>
    {
        private readonly ICrudRepository<BookingDetailsItem, int> _bookingRepository;
        public BookingDetailsService(ICrudRepository<BookingDetailsItem, int> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public void Add(BookingDetailsItem element)
        {
            _bookingRepository.Add(element);
            _bookingRepository.Save();
        }
        public void Delete(int id)
        {
            _bookingRepository.Delete(id);
            _bookingRepository.Save();
        }
        public BookingDetailsItem Get(int id)
        {
            return _bookingRepository.Get(id);
        }
        public IEnumerable<BookingDetailsItem> GetAll()
        {
            return _bookingRepository.GetAll();
        }
        public void Update(BookingDetailsItem old, BookingDetailsItem newT)
        {
            old.fName = newT.fName;
            old.lName = newT.lName;
            _bookingRepository.Update(old);
            _bookingRepository.Save();
        }
    }
}
