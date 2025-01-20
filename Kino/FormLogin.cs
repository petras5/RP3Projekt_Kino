using Kino.model;
using Kino.services;
using Kino.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino
{
    /// <summary>
    /// Form for user login.
    /// </summary>
    public partial class FormLogin : Form
    {
        Form FormRegister { get; set; } // Reference to the registration form.

        /// <summary>
        /// Constructor for FormLogin.
        /// </summary>
        /// <param name="formRegister">The registration form instance.</param>
        public FormLogin(Form formRegister)
        {
            InitializeComponent();
            FormRegister = formRegister;
        }

        /// <summary>
        /// Handles the Login button click event to authenticate the user.
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService(labelStatus);
            if (textBoxPassword.Text == string.Empty || textBoxUsername.Text == string.Empty)
            {
                labelStatus.Text = "All spaces are mandatory. Login failed. ";
                return;
            }
            User user = userService.VerifyUser(textBoxUsername.Text, textBoxPassword.Text);
            if (user != null)
            {
                //new FormHomePage(FormRegister,user).Show();
                new FormNavigation(FormRegister, user).Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Clears all input fields and status messages.
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            labelStatus.Text = string.Empty;
        }

        /// <summary>
        /// Toggles the visibility of the password text field.
        /// </summary>
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
            }
        }

        /// <summary>
        /// Handles the event to navigate to the registration form.
        /// </summary>
        private void labelCreateAccount_Click(object sender, EventArgs e)
        {
            FormRegister.Show();
            this.Close();
        }

        /// <summary>
        /// Closes the application using reference to registration form.
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormRegister.Close();
        }
    }
}
