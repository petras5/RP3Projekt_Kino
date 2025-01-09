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
    public partial class FormOverviewProjections : Form
    {

        User User { get; set; }
        Form FormRegister { get; set; }

        string movieID;

        public FormOverviewProjections(Form formRegister, User user, string id)
        {
            InitializeComponent();
            User = user;
            FormRegister = formRegister;
            movieID = id;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

            labelStatus.Text = $"Movie with index {movieID}";
        }
    }
}
