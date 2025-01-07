using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.model
{
    public class Movie
    {
        public int IdMovie { get; set; }
        public string NameMovie { get; set; }
        public string Description { get; set; }

        public Movie(int idMovie, string nameMovie, string description)
        {
            IdMovie = idMovie;
            NameMovie = nameMovie;
            Description = description;
        }
    }
}
