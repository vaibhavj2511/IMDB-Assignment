using System.Collections.Generic;
using SessionDemoApp.Models;
using SessionDemoApp.Repository;

namespace SessionDemoApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, IActorRepository actorRepository, IProducerRepository producerRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _producerRepository = producerRepository;
            _genreRepository = genreRepository;
        }


        public IEnumerable<MovieDto> GetAll()
        {
            var movies = _movieRepository.GetAll();
            var movieDtoCollection = new List<MovieDto>();

            foreach (var movie in movies)
            {
                var actor = _actorRepository.GetActorsByMovieId(movie.Id);
                var genre = _genreRepository.GetGenresByMovieId(movie.Id);
                var producer = _producerRepository.GetById(movie.ProducerId);
                var movieDto = new MovieDto
                {

                    Id = movie.Id,
                    Name = movie.Name,
                    YOR = movie.YOR,
                    Plot = movie.Plot,
                    Actor = (List<Actor>)actor,
                    Genre = (List<Genre>)genre,
                    Producers = producer
                };
                movieDtoCollection.Add(movieDto);
            }
            return movieDtoCollection;
        }


        public int Create(FormBody movie)
        {
            var entity = new Movie
            {
                Name = movie.Name,
                Plot = movie.Plot,
                YOR = movie.YOR,
                ProducerId = movie.ProducerId
            };

            return _movieRepository.Create(entity, movie.Actors, movie.Genres);
        }


        public bool Update(int id, FormBody movie)
        {
            var MovieExist = _movieRepository.GetById(id);
            if (MovieExist == null) return false;
            var entity = new Movie
            {
                Name = movie.Name,
                Plot = movie.Plot,
                YOR = movie.YOR,
                ProducerId = movie.ProducerId
            };

            _movieRepository.Update(id, entity, movie.Actors, movie.Genres);
            return true;
        }
    }
}


