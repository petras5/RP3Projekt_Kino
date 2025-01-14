using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.model
{
    public class Receipt
    {
        public int IdReceipt { get; set; }
        public int IdUser { get; set; }
        public DateTime Created { get; set; }
        public decimal Total { get; set; }

        public Receipt(int idReceipt, int idUser, DateTime created, decimal total)
        {
            IdReceipt = idReceipt;
            IdUser = idUser;
            Created = created;
            Total = total;
        }
    }
}
