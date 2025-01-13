using Kino.model;
using Kino.services;
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
    public partial class FormReservations : Form
    {
        User User { get; set; }
        Form FormRegister { get; set; }
        public FormReservations(Form formRegister, User user)
        {
            InitializeComponent();
            User = user;
            FormRegister = formRegister;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

            labelStatus.Text = "";

            //FillData();
        }

        /*
        private void FillData()
        {
            UserService userService = new UserService(labelStatus);
            List<User> users = userService.GetUsers();

            UserService userService = new UserService(labelStatus);
            List<User> users = userService.GetUsers();

            var combobox = (DataGridViewComboBoxColumn)dataGridView1.Columns[4];
            combobox.DataSource = new BindingSource(roles, null);
            combobox.DisplayMember = "Value";
            combobox.ValueMember = "Key";

            foreach (User user in users)
            {
                dataGridView1.Rows.Add(user.IdUser, user.Name, user.Surname, user.Username, user.Role);
            }

        }
        */
    }
}
