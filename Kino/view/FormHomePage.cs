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
    public partial class FormHomePage : Form
    {
        User User { get; set; }
        Form FormRegister { get; set; }
        public FormHomePage(Form formRegister, User user)
        {
            InitializeComponent();
            User = user;
            FormRegister = formRegister;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormRegister.Close();
        }
    }
}
