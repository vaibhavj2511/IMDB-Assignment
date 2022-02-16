using System.Collections.Generic;
using SessionDemoApp.Models;

namespace SessionDemoApp.Repository
{
    public interface IActorRepository
    {
        public IEnumerable<Actor> GetActorsByMovieId(int id);
    }
}
