using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SessionDemoApp.Models;

namespace SessionDemoApp.Services
{
    public interface IMovieService
    {
        public IEnumerable<MovieDto> GetAll();
        public int Create(FormBody movie);
        public bool Update(int id, FormBody movie);
    }
}
