﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.model
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public int IdProjection { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public decimal Price { get; set; }
        public int IdReceipt { get; set; }

        public Reservation(int idReservation, int idProjection, int row, int column, decimal price, int idReceipt)
        {
            IdReservation = idReservation;
            IdProjection = idProjection;
            Row = row;
            Column = column;
            Price = price;
            IdReceipt = idReceipt;
        }
    }
}
