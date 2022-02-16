using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionDemoApp.Models
{
    public class FormBody
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YOR { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
        public List<int> Actors { get; set; }

        public List<int> Genres { get; set; }
    }
}
