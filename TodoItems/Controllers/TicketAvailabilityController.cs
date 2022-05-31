using Microsoft.AspNetCore.Mvc;
using TodoItems.Services;

namespace TodoItems.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: api/todo
    public class TicketAvailabilityController : ControllerBase
    {
        private readonly ICrudService<TicketAvailabilityItem, int> _ticketAService;
        public TicketAvailabilityController(ICrudService<TicketAvailabilityItem, int> ticketAService)
        {
            _ticketAService = ticketAService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<TicketAvailabilityItem>> GetAll() => _ticketAService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<TicketAvailabilityItem> Get(int id)
        {
            var ticketA = _ticketAService.Get(id);
            if (ticketA is null) return NotFound();
            else return ticketA;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(TicketAvailabilityItem ticketA)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _ticketAService.Add(ticketA);
                return CreatedAtAction(nameof(Create), new { id = ticketA.Id }, ticketA);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, TicketAvailabilityItem ticketA)
        {
            var existingTicketAvailabilityItem = _ticketAService.Get(id);
            if (existingTicketAvailabilityItem is null || existingTicketAvailabilityItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _ticketAService.Update(existingTicketAvailabilityItem, ticketA);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ticketA = _ticketAService.Get(id);
            if (ticketA is null) return NotFound();
            _ticketAService.Delete(id);
            return NoContent();
        }
    }
}


