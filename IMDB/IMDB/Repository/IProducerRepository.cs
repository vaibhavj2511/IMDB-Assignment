using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SessionDemoApp.Models;

namespace SessionDemoApp.Repository
{
    public interface IProducerRepository
    { 
        public Producer GetById(int Id);
    }
}
