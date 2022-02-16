using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SessionDemoApp.Models;

namespace SessionDemoApp.Repository
{
    public interface IMovieRepository
    {
        public Movie GetById(int id);
        public IEnumerable<Movie> GetAll();
        public int Create(Movie movie, List<int> actors, List<int> genres);
        public void Update(int id, Movie movie, List<int> actors, List<int> genres);
    }
}
