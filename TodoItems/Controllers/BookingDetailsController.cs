using Microsoft.AspNetCore.Mvc;
using TodoItems.Services;

namespace TodoItems.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: api/todo
    public class BookingDetailsController : ControllerBase
    {
        private readonly ICrudService<BookingDetailsItem, int> _bookingService;
        public BookingDetailsController(ICrudService<BookingDetailsItem, int> bookingService)
        {
            _bookingService = bookingService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<BookingDetailsItem>> GetAll() => _bookingService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<BookingDetailsItem> Get(int id)
        {
            var booking = _bookingService.Get(id);
            if (booking is null) return NotFound();
            else return booking;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(BookingDetailsItem booking)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _bookingService.Add(booking);
                return CreatedAtAction(nameof(Create), new { id = booking.Id }, booking);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, BookingDetailsItem booking)
        {
            var existingBookingDetailsItem = _bookingService.Get(id);
            if (existingBookingDetailsItem is null || existingBookingDetailsItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _bookingService.Update(existingBookingDetailsItem, booking);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var booking = _bookingService.Get(id);
            if (booking is null) return NotFound();
            _bookingService.Delete(id);
            return NoContent();
        }
    }
}

