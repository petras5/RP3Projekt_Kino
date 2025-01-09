using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.model
{
    internal class Receipt
    {
        public int IdReceipt { get; set; }
        public int IdUser { get; set; }
        public DateTime Created { get; set; }

        public Receipt(int idReceipt, int idUser, DateTime created)
        {
            IdReceipt = idReceipt;
            IdUser = idUser;
            Created = created;
        }
    }
}
