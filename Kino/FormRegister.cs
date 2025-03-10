﻿using Kino.model;
using Kino.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Kino
{
    /// <summary>
    /// Form for user registration.
    /// </summary>
    public partial class FormRegister : Form
    {
        /// <summary>
        /// Constructor for FormRegister.
        /// </summary>
        public FormRegister()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handles the Register button click event to validate user inputs and register a new user.
        /// </summary>
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService(labelStatus);
            if (textBoxName.Text == string.Empty || textBoxSurname.Text == string.Empty 
                || textBoxPassword.Text == string.Empty || textBoxConfirmPassword.Text == string.Empty
                || textBoxUsername.Text == string.Empty)
            {
                labelStatus.Text = "All spaces are mandatory. Register failed. ";
                return;
            } 
            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                labelStatus.Text = "Password and Confirm password must match.";
                textBoxPassword.Text = string.Empty;
                textBoxConfirmPassword.Text = string.Empty;
                textBoxPassword.Focus();
                return;
            } 
            if (userService.GetExistingUserByUsername(textBoxUsername.Text) != null)
            {
                return;
            }
            if (!Regex.IsMatch(textBoxUsername.Text, @"^[A-Za-z0-9_]{3,20}$"))
            {
                labelStatus.Text = "Username must be between 3 and 20 characters and contain only letters, numbers, and underscores.";
                return;
            }
            if (!Regex.IsMatch(textBoxName.Text, @"^\p{L}{1,20}$") || !Regex.IsMatch(textBoxSurname.Text, @"^\p{L}{1,20}$"))
            {
                labelStatus.Text = "First Name and Last Name should be between 1 and 20 LETTERS.";
                return;
            }
            if (!Regex.IsMatch(textBoxPassword.Text, @"^(?=.*\d).{8,}$"))
            {
                labelStatus.Text = "Password needs to have a minimum length of 8 and at least one letter and one number.";
                return;
            }

            User newUser = userService.InsertUser(textBoxUsername.Text, textBoxName.Text, textBoxSurname.Text, textBoxPassword.Text);
            if (newUser == null)
            {
                labelStatus.Text = "Error in adding new user. Please try again.";
            }
            else
            {
                labelStatus.Text = "User registered successfully. You can login now.";
                new FormLogin(this).Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Handles the event for showing or hiding the password text fields.
        /// </summary>
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
                textBoxConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
                textBoxConfirmPassword.PasswordChar = '*';
            }
        }

        /// <summary>
        /// Clears all input fields and status messages.
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxSurname.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            textBoxConfirmPassword.Text = string.Empty;
            labelStatus.Text = string.Empty;
        }

        /// <summary>
        /// Navigates back to the login form when the label is clicked.
        /// </summary>
        private void labelBackLogin_Click(object sender, EventArgs e)
        {
            new FormLogin(this).Show();
            this.Hide();
        }

        /// <summary>
        /// Exits the application when the Exit button is clicked.
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
