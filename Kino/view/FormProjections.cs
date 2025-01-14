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
    public partial class FormProjections : Form
    {
        User User { get; set; }
        Form FormRegister { get; set; }
        public FormProjections(Form formRegister, User user)
        {
            InitializeComponent();
            User = user;
            FormRegister = formRegister;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;
            DoubleBuffered = true;
        }
    }
}
