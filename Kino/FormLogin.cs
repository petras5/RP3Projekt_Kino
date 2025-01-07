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
    public partial class FormLogin : Form
    {
        Form FormRegister { get; set; }
        public FormLogin(Form formRegister)
        {
            InitializeComponent();
            FormRegister = formRegister;
        }

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
                new FormHomePage(FormRegister,user).Show();
                this.Hide();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
        }

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

        private void labelCreateAccount_Click(object sender, EventArgs e)
        {
            FormRegister.Show();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormRegister.Close();
        }
    }
}
