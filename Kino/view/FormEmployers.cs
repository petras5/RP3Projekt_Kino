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
        Form FormRegister { get; set; }
        public FormEmployers(Form formRegister, User user)
        {
            InitializeComponent();
            User = user;
            FormRegister = formRegister;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

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

            var combobox = (DataGridViewComboBoxColumn)dataGridView1.Columns[3];
            combobox.DataSource = new BindingSource(roles, null);
            combobox.DisplayMember = "Value";
            combobox.ValueMember = "Key";

            foreach (User user in users)
            {
                dataGridView1.Rows.Add(user.IdUser, user.Name, user.Surname, user.Username, user.Role);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Role")
            {
                // Get the updated value
                var selectedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Perform your logic
                if (selectedValue != null)
                {
                    MessageBox.Show($"Role changed to: {selectedValue}");
                }

                buttonSubmit.Enabled = true;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService(labelStatus);

            List<User> users = userService.GetUsers();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].IsNewRow)
                {
                    var userID = dataGridView1.Rows[i].Cells["User ID"].Value?.ToString();
                    //var username = dataGridView1.Rows[i].Cells["Username"].Value?.ToString();
                    //Console.WriteLine($"Row {i}: Username = {username}");
                    //if() ....TO BE CONTINUED
                }
            }


            foreach (User user in users)
            {
                
            }

        }
    }
}
