using Microsoft.AspNetCore.Mvc;
using TodoItems.Services;

namespace TodoItems.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: api/todo
    public class MovieController : ControllerBase
    {
        private readonly ICrudService<MovieItem, int> _movieService;
        public MovieController(ICrudService<MovieItem, int> movieService)
        {
            _movieService = movieService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<MovieItem>> GetAll() => _movieService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<MovieItem> Get(int id)
        {
            var movie = _movieService.Get(id);
            if (movie is null) return NotFound();
            else return movie;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(MovieItem movie)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _movieService.Add(movie);
                return CreatedAtAction(nameof(Create), new { id = movie.Id }, movie);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, MovieItem movie)
        {
            var existingMovieItem = _movieService.Get(id);
            if (existingMovieItem is null || existingMovieItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _movieService.Update(existingMovieItem, movie);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.Get(id);
            if (movie is null) return NotFound();
            _movieService.Delete(id);
            return NoContent();
        }
    }
}

