using System;
using System.Collections.Generic;
using SessionDemoApp.Helper;
using SessionDemoApp.Models;

namespace SessionDemoApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ISqlHelper<Movie> _sqlHelper;
        public MovieRepository(ISqlHelper<Movie> sqlHelper)
        {
            this._sqlHelper = sqlHelper;
        }

        public IEnumerable<Movie> GetAll()
        {
            string sql = @"SELECT Id [Id]
	                                ,Name [Name]
	                                ,YOR [YOR]
	                                ,Plot [Plot]
	                                ,ProducersId [ProducerId]
                           FROM Movies";


            return _sqlHelper.Query(sql);

        }

        public Movie GetById(int id)
        {
            string sql = @"SELECT Id [Id]
	                                ,Name [Name]
	                                ,YOR [YOR]
	                                ,Plot [Plot]
	                                ,Poster [Poster]
	                                ,producersId [ProducerId]
                            FROM Movies
                            WHERE Movies.Id = @id";



            return _sqlHelper.SingleQuery(sql, new { id });
        }


        public int Create(Movie movie, List<int> actor, List<int> genre)
        {

            string sql = @"DECLARE @MoviesId INT

                            INSERT INTO Movies (
	                            Name
	                            ,YOR
	                            ,Plot
	                            ,ProducersId
	                            )
                            VALUES (
	                            @Name
	                            ,@YOR
	                            ,@Plot
	                            ,@producersId
	                            )

                            SET @MoviesId = SCOPE_IDENTITY()

                            INSERT INTO MovieActorMapping (
	                            MoviesID
	                            ,ActorsId
	                            )
                            SELECT (
		                            SELECT @MoviesId
		                            )
	                            ,t.Actors
                            FROM (
	                            SELECT value AS Actors
	                            FROM string_split(@Actors, ',')
	                            ) t

                            INSERT INTO MovieGenreMapping (
	                            MoviesID
	                            ,GenresId
	                            )
                            SELECT (
		                            SELECT @MoviesId
		                            )
	                            ,t.Genres
                            FROM (
	                            SELECT value AS Genres
	                            FROM string_split(@Genres, ',')
	                            ) t

                            SELECT @MoviesId";



            return _sqlHelper.Insert(sql, new
            {
                movie.Name,
                movie.YOR,
                movie.Plot,
                producersId = movie.ProducerId,
                Actors = string.Join(",", actor),
                Genres = string.Join(",", genre)

            });

        }

        public void Update(int id, Movie movie, List<int> actors, List<int> genres)
        {
            string sql = @"UPDATE Movies
                            SET Name = @Name
	                            ,YOR = @YOR
	                            ,Plot = @Plot
	                            ,ProducersId = @ProducersId
                            WHERE Movies.Id = @id

                            DELETE
                            FROM MovieActorMapping
                            WHERE MoviesId = @id

                            DELETE
                            FROM MovieGenreMapping
                            WHERE MoviesId = @id

                            INSERT INTO MovieActorMapping (
	                                    MoviesID
	                                    ,ActorsId
	                                    )
                            SELECT (
		                            SELECT @id
		                            )
	                            ,t.Actors

                            FROM (
	                            SELECT value AS Actors
	                            FROM string_split(@Actors, ',')
	                            ) t

                            INSERT INTO MovieGenreMapping (
	                            MoviesID
	                            ,GenresId
	                            )

                            SELECT (
		                            SELECT @id
		                            )
	                            ,t.Genres

                            FROM (
	                            SELECT value AS Genres
	                            FROM string_split(@Genres, ',')
	                            ) t";

            _sqlHelper.Execute(sql, new
            {
                movie.Name,
                movie.YOR,
                movie.Plot,
                ProducersId = movie.ProducerId,
                id,
                Actors = string.Join(",", actors),
                Genres = string.Join(",", genres)
            });

        }
    }
}
