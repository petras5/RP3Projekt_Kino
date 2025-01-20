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
    /// <summary>
    /// FormNavigation class manages the main navigation within the application.
    /// It displays different screens (panels) based on the user's selection, such as Home, Receipts, Projections, 
    /// and administrative features like adding movies, projections, or managing employers.
    /// </summary>
    public partial class FormNavigation : Form
    {
        /// <summary>
        /// The currently logged-in user.
        /// Determines the access level and displayed options based on their role.
        /// </summary>
        User User { get; set; }

        /// <summary>
        /// Initial application form.
        /// Returns to this form when the user logs out.
        /// </summary>
        Form FormRegister { get; set; }

        /// <summary>
        /// Constructor for FormNavigation.
        /// Sets up the default screen (Home) and configures UI elements based on user role.
        /// </summary>
        /// <param name="formRegister">The parent form for registration.</param>
        /// <param name="user">The logged-in user.</param>
        public FormNavigation(Form formRegister, User user)
        {
            InitializeComponent();
            DoubleBuffered = true;
            User = user;
            FormRegister = formRegister;
            labelUsername.Text = $"{user.Name} {user.Surname}";

            panelNavLine.Height = buttonHome.Height;
            panelNavLine.Top = buttonHome.Top;
            panelNavLine.Left = buttonHome.Left;
            buttonHome.BackColor = Color.FromArgb(94, 134, 144);

            this.panelFormLoader.Controls.Clear();
            FormHomePage formHomePage = new FormHomePage(this, User);
            formHomePage.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formHomePage);
            formHomePage.Show();

            if(User.Role == 1)
            {
                buttonEmployers.Visible = false;
                buttonNewMovie.Visible = false;
                buttonNewProjection.Visible = false;
            }
        }

        /// <summary>
        /// Handles the Exit button click event to close the application entirely.
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormRegister.Close();
        }

        /// <summary>
        /// Handles the Logout button click event to return to the registration screen.
        /// </summary>
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormRegister.Show(); 
            this.Close();
        }

        /// <summary>
        /// Handles navigation to the Home screen when the Home button is clicked.
        /// </summary>
        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelFormLoader.SuspendLayout();

            panelNavLine.Height = buttonHome.Height;
            panelNavLine.Top = buttonHome.Top;
            panelNavLine.Left = buttonHome.Left;
            buttonHome.BackColor = Color.FromArgb(94, 134, 144); //NERADI, trebalo bi is button clicked, reset buttons, bezveze, nedamise sad...
            buttonReceipts.BackColor = Color.FromArgb(20, 139, 160);
            buttonProjections.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewProjection.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewMovie.BackColor = Color.FromArgb(20, 139, 160);
            buttonEmployers.BackColor = Color.FromArgb(20, 139, 160);

            this.panelFormLoader.Controls.Clear();
            FormHomePage formHomePage = new FormHomePage(this, User);
            formHomePage.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formHomePage);
            formHomePage.Show();

            panelFormLoader.ResumeLayout();
        }

        /// <summary>
        /// Handles navigation to the Receipts screen when the Receipts button is clicked.
        /// </summary>
        private void buttonReceipts_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonReceipts.Height;
            panelNavLine.Top = buttonReceipts.Top;
            panelNavLine.Left = buttonReceipts.Left;
            buttonReceipts.BackColor = Color.FromArgb(94, 134, 144);
            buttonHome.BackColor = Color.FromArgb(20, 139, 160);
            buttonProjections.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewProjection.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewMovie.BackColor = Color.FromArgb(20, 139, 160);
            buttonEmployers.BackColor = Color.FromArgb(20, 139, 160);

            this.panelFormLoader.Controls.Clear();
            FormReceipts formReservations = new FormReceipts(this, User);
            formReservations.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formReservations);
            formReservations.Show();
        }

        /// <summary>
        /// Handles navigation to the Projections screen when the Projections button is clicked.
        /// </summary>
        private void buttonProjections_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonProjections.Height;
            panelNavLine.Top = buttonProjections.Top;
            panelNavLine.Left = buttonProjections.Left;
            buttonProjections.BackColor = Color.FromArgb(94, 134, 144);
            buttonHome.BackColor = Color.FromArgb(20, 139, 160);
            buttonReceipts.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewProjection.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewMovie.BackColor = Color.FromArgb(20, 139, 160);
            buttonEmployers.BackColor = Color.FromArgb(20, 139, 160);

            this.panelFormLoader.Controls.Clear();
            FormProjections formProjections = new FormProjections(this, User);
            formProjections.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formProjections);
            formProjections.Show();
        }

        /// <summary>
        /// Handles navigation to the New Projection screen when the New Projection button is clicked.
        /// </summary>
        private void buttonNewProjection_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonNewProjection.Height;
            panelNavLine.Top = buttonNewProjection.Top;
            panelNavLine.Left = buttonNewProjection.Left;
            buttonNewProjection.BackColor = Color.FromArgb(94, 134, 144);
            buttonHome.BackColor = Color.FromArgb(20, 139, 160);
            buttonReceipts.BackColor = Color.FromArgb(20, 139, 160);
            buttonProjections.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewMovie.BackColor = Color.FromArgb(20, 139, 160);
            buttonEmployers.BackColor = Color.FromArgb(20, 139, 160);

            this.panelFormLoader.Controls.Clear();
            FormNewProjection formNewProjection = new FormNewProjection(User);
            formNewProjection.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formNewProjection);
            formNewProjection.Show();
        }

        /// <summary>
        /// Handles navigation to the New Movie screen when the New Movie button is clicked.
        /// </summary>
        private void buttonNewMovie_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonNewMovie.Height;
            panelNavLine.Top = buttonNewMovie.Top;
            panelNavLine.Left = buttonNewMovie.Left;
            buttonNewMovie.BackColor = Color.FromArgb(94, 134, 144);
            buttonHome.BackColor = Color.FromArgb(20, 139, 160);
            buttonReceipts.BackColor = Color.FromArgb(20, 139, 160);
            buttonProjections.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewProjection.BackColor = Color.FromArgb(20, 139, 160);
            buttonEmployers.BackColor = Color.FromArgb(20, 139, 160);

            this.panelFormLoader.Controls.Clear();
            FormNewMovie formNewMovie = new FormNewMovie(User);
            formNewMovie.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formNewMovie);
            formNewMovie.Show();
        }

        /// <summary>
        /// Handles navigation to the Employers screen when the Employers button is clicked.
        /// </summary>
        private void buttonEmployers_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonEmployers.Height;
            panelNavLine.Top = buttonEmployers.Top;
            panelNavLine.Left = buttonEmployers.Left;
            buttonEmployers.BackColor = Color.FromArgb(94, 134, 144);
            buttonHome.BackColor = Color.FromArgb(20, 139, 160);
            buttonReceipts.BackColor = Color.FromArgb(20, 139, 160);
            buttonProjections.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewProjection.BackColor = Color.FromArgb(20, 139, 160);
            buttonNewMovie.BackColor = Color.FromArgb(20, 139, 160);

            this.panelFormLoader.Controls.Clear();
            FormEmployers formEmployers = new FormEmployers(User);
            formEmployers.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formEmployers);
            formEmployers.Show();
        }
    }
}
