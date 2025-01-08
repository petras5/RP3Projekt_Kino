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
    public partial class FormNewProjection : Form
    {
        User User { get; set; }
        Form FormRegister { get; set; }
        public FormNewProjection(Form formRegister, User user)
        {
            InitializeComponent();
            User = user;
            FormRegister = formRegister;
        }

        //slucajno dodano...
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
