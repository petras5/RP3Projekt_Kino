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
    public partial class FormEmployers : Form
    {
        User User { get; set; }
        public FormEmployers(User user)
        {
            InitializeComponent();
            User = user;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;
            DoubleBuffered = true;

            labelStatus.Text = "";

            FillData();
        }

        
        Dictionary<int, string> roles = new Dictionary<int, string>() {
                                  {1, "Employee"},
                                  {2, "Admin"}  };

        private void FillData()
        {
            UserService userService = new UserService(labelStatus);

            List<User> users = userService.GetUsers();

            var combobox = (DataGridViewComboBoxColumn)dataGridView1.Columns[4];
            combobox.DataSource = new BindingSource(roles, null);
            combobox.DisplayMember = "Value";
            combobox.ValueMember = "Key";

            foreach (User user in users)
            {
                if (user.IdUser != User.IdUser)
                {
                    dataGridView1.Rows.Add(user.IdUser, user.Name, user.Surname, user.Username, user.Role);
                }
                
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Role")
            {
                //var selectedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                buttonSubmit.Enabled = true;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService(labelStatus);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].IsNewRow)
                {
                    int userID = (int)dataGridView1.Rows[i].Cells["UserID"].Value;
                    int role = (int)dataGridView1.Rows[i].Cells["Role"].Value;

                    User userChange = userService.GetUserById(userID);

                    if(userChange.Role != role)
                    {
                        userService.UpdateUserRole(userID, role);
                    }
                }
            }
            buttonSubmit.Enabled = false;
        }
    }
}
