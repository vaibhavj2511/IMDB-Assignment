using System.Collections.Generic;
using SessionDemoApp.Helper;
using SessionDemoApp.Models;

namespace SessionDemoApp.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly ISqlHelper<Actor> _sqlHelper;

        public ActorRepository(ISqlHelper<Actor> sqlHelper)
        {
            this._sqlHelper = sqlHelper;
        }

        public IEnumerable<Actor> GetActorsByMovieId(int id)
        {
            string sql = @"SELECT a.Id [Id]
	                                ,a.Name [Name]
	                                ,a.DOB [DateOfBirth]
	                                ,a.Bio [Bio]
	                                ,a.Gender [Gender]
                            FROM Actors a
                            INNER JOIN MovieActorMapping m ON a.Id = m.ActorsId
                            WHERE m.MoviesId = @id";


            return _sqlHelper.Query(sql, new { id });
        }

    }
}
