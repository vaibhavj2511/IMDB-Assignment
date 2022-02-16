using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using SessionDemoApp.Helper;
using SessionDemoApp.Models;

namespace SessionDemoApp.Repository
{
    public class GenreRepository : IGenreRepository
    {

        private readonly ISqlHelper<Genre> _sqlHelper;
        public GenreRepository(ISqlHelper<Genre> sqlHelper)
        {
            this._sqlHelper = sqlHelper;
        }

        public IEnumerable<Genre> GetGenresByMovieId(int id)
        {
            string sql = @"SELECT a.Id [Id]
	                                ,a.Name [Name]
                            FROM Genres a
                            INNER JOIN MovieGenreMapping m ON a.Id = m.GenresId
                            WHERE m.moviesId = @id";


            return _sqlHelper.Query(sql, new { id });
        }
    }
}
