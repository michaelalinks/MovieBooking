using TodoItems.Controllers;

namespace TodoItems.Data.Repositories
{
    public class MovieRepository : ICrudRepository<MovieItem, int>
    {

        private readonly TodoContext _movieContext;
        public MovieRepository(TodoContext movieContext)
        {
            _movieContext = movieContext ?? throw new
            ArgumentNullException(nameof(movieContext));
        }
        public void Add(MovieItem element)
        {
            _movieContext.MovieItems.Add(element);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _movieContext.MovieItems.Remove(Get(id));
        }

        public bool Exists(int id)
        {
            return _movieContext.MovieItems.Any(u => u.Id == id);
        }

        public MovieItem Get(int id)
        {
            return _movieContext.MovieItems.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<MovieItem> GetAll()
        {
            return _movieContext.MovieItems.ToList();
        }

        public bool Save()
        {
            return _movieContext.SaveChanges() > 0;
        }

        public void Update(MovieItem element)
        {
            _movieContext.Update(element);
        }
    }
}

