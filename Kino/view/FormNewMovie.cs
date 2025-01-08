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
    public partial class FormNewMovie : Form
    {
        User User { get; set; }
        Form FormRegister { get; set; }
        public FormNewMovie(Form formRegister, User user)
        {
            InitializeComponent();
            User = user;
            FormRegister = formRegister;
        }
    }
}
