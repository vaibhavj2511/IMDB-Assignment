using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SessionDemoApp.Models;

namespace SessionDemoApp.Repository
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> GetGenresByMovieId(int id);
    }
}
