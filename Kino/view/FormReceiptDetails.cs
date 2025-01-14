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
        Form FormRegister { get; set; }

        string receiptID;

        public FormReceiptDetails(Form formRegister, User user, string id)
        {
            InitializeComponent();
            User = user;
            FormRegister = formRegister;
            receiptID = id;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

            labelStatus.Text = $"Receipt with index {receiptID}";
        }
    }
}
