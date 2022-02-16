using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionDemoApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YOR { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
    }
}
