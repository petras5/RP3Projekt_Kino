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
    public partial class FormNavigation : Form
    {
        User User { get; set; }
        Form FormRegister { get; set; }

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
            FormHomePage formHomePage = new FormHomePage(FormRegister, this, User);
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

        //slucajno...
        private void FormNavigation_Load(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormRegister.Close();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormRegister.Show(); 
            this.Close();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelFormLoader.SuspendLayout();

            panelNavLine.Height = buttonHome.Height;
            panelNavLine.Top = buttonHome.Top;
            panelNavLine.Left = buttonHome.Left;
            buttonHome.BackColor = Color.FromArgb(94, 134, 144); //NERADI, trebalo bi is button clicked, reset buttons, bezveze, nedamise sad...

            this.panelFormLoader.Controls.Clear();
            FormHomePage formHomePage = new FormHomePage(FormRegister, this, User);
            formHomePage.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formHomePage);
            formHomePage.Show();

            panelFormLoader.ResumeLayout();
        }

        private void buttonReceipts_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonReceipts.Height;
            panelNavLine.Top = buttonReceipts.Top;
            panelNavLine.Left = buttonReceipts.Left;
            buttonReceipts.BackColor = Color.FromArgb(94, 134, 144);

            this.panelFormLoader.Controls.Clear();
            FormReceipts formReservations = new FormReceipts(FormRegister, this, User);
            formReservations.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formReservations);
            formReservations.Show();
        }

        private void buttonProjections_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonProjections.Height;
            panelNavLine.Top = buttonProjections.Top;
            panelNavLine.Left = buttonProjections.Left;
            buttonProjections.BackColor = Color.FromArgb(94, 134, 144);

            this.panelFormLoader.Controls.Clear();
            FormProjections formProjections = new FormProjections(FormRegister, User);
            formProjections.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formProjections);
            formProjections.Show();
        }

        private void buttonNewProjection_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonNewProjection.Height;
            panelNavLine.Top = buttonNewProjection.Top;
            panelNavLine.Left = buttonNewProjection.Left;
            buttonNewProjection.BackColor = Color.FromArgb(94, 134, 144);

            this.panelFormLoader.Controls.Clear();
            FormNewProjection formNewProjection = new FormNewProjection(User);
            formNewProjection.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formNewProjection);
            formNewProjection.Show();
        }

        private void buttonNewMovie_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonNewMovie.Height;
            panelNavLine.Top = buttonNewMovie.Top;
            panelNavLine.Left = buttonNewMovie.Left;
            buttonNewMovie.BackColor = Color.FromArgb(94, 134, 144);

            this.panelFormLoader.Controls.Clear();
            FormNewMovie formNewMovie = new FormNewMovie(User);
            formNewMovie.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formNewMovie);
            formNewMovie.Show();
        }

        private void buttonEmployers_Click(object sender, EventArgs e)
        {
            panelNavLine.Height = buttonEmployers.Height;
            panelNavLine.Top = buttonEmployers.Top;
            panelNavLine.Left = buttonEmployers.Left;
            buttonEmployers.BackColor = Color.FromArgb(94, 134, 144);

            this.panelFormLoader.Controls.Clear();
            FormEmployers formEmployers = new FormEmployers(FormRegister, User);
            formEmployers.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formEmployers);
            formEmployers.Show();
        }

        private void buttonHome_Leave(object sender, EventArgs e)
        {
            buttonHome.BackColor = Color.FromArgb(20, 139, 160);
        }

        private void buttonReservations_Leave(object sender, EventArgs e)
        {
            buttonReceipts.BackColor = Color.FromArgb(20, 139, 160);
        }

        private void buttonProjections_Leave(object sender, EventArgs e)
        {
            buttonProjections.BackColor = Color.FromArgb(20, 139, 160);
        }

        private void buttonNewProjection_Leave(object sender, EventArgs e)
        {
            buttonNewProjection.BackColor = Color.FromArgb(20, 139, 160);
        }

        private void buttonNewMovie_Leave(object sender, EventArgs e)
        {
            buttonNewMovie.BackColor = Color.FromArgb(20, 139, 160);
        }

        private void buttonEmployee_Leave(object sender, EventArgs e)
        {
            buttonEmployers.BackColor = Color.FromArgb(20, 139, 160);
        }
    }
}
