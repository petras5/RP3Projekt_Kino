using Kino.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.view
{
    public partial class FormReceiptDetails : Form
    {
        User User { get; set; }

        Receipt Receipt { get; set; }

        public FormReceiptDetails(User user, Receipt receipt)
        {
            InitializeComponent();
            User = user;
            Receipt = receipt;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;
            DoubleBuffered = true;

            labelStatus.Text = $"Receipt with index {Receipt.IdReceipt}";
        }
    }
}
