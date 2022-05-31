using TodoItems.Controllers;
using TodoItems.Data.Repositories;

namespace TodoItems.Services
{
    public class MovieService : ICrudService<MovieItem, int>
    {
        private readonly ICrudRepository<MovieItem, int> _movieRepository;
        public MovieService(ICrudRepository<MovieItem, int> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public void Add(MovieItem element)
        {
            _movieRepository.Add(element);
            _movieRepository.Save();
        }
        public void Delete(int id)
        {
            _movieRepository.Delete(id);
            _movieRepository.Save();
        }
        public MovieItem Get(int id)
        {
            return _movieRepository.Get(id);
        }
        public IEnumerable<MovieItem> GetAll()
        {
            return _movieRepository.GetAll();
        }
        public void Update(MovieItem old, MovieItem newT)
        {
            old.MovieTitle = newT.MovieTitle;
            _movieRepository.Update(old);
            _movieRepository.Save();
        }
    }
}
