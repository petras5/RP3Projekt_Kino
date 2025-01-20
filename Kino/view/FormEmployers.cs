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
    /// <summary>
    /// Form for managing employers, including viewing and updating their roles.
    /// </summary>
    public partial class FormEmployers : Form
    {
        User User { get; set; } // currently logged-in user

        /// <summary>
        /// Constructor for FormEmployers.
        /// </summary>
        /// <param name="user"> currently logged-in user </param>
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

        
        // Dictionary containing role IDs and their corresponding names.
        Dictionary<int, string> roles = new Dictionary<int, string>() {
                                  {1, "Employee"},
                                  {2, "Admin"}  };

        /// <summary>
        /// Fills the DataGridView with user data.
        /// </summary>
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

        /// <summary>
        /// Enables the submit button when a role is changed in the DataGridView.
        /// </summary>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Role")
            {
                buttonSubmit.Enabled = true;
            }
        }

        /// <summary>
        /// Submits the changes made to user roles in the DataGridView.
        /// </summary>
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
