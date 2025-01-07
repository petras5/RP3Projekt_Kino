using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.model
{
    public class Projection
    {
        public int IdProjection { get; set; }
        public int IdHall { get; set; }
        public int IdMovie { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int RegularPrice { get; set; }

        public Projection(int idProjection, int idHall, int idMovie, DateTime date, TimeSpan time, int regularPrice)
        {
            IdProjection = idProjection;
            IdHall = idHall;
            IdMovie = idMovie;
            Date = date;
            Time = time;
            RegularPrice = regularPrice;
        }
    }
}
