using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.model
{
    internal class Hall
    {
        public int IdHall { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

        public Hall(int idHall, int rowCount, int columnCount)
        {
            IdHall = idHall;
            RowCount = rowCount;
            ColumnCount = columnCount;
        }
    }
}
