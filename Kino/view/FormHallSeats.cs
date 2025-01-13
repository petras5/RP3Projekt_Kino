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
    public partial class FormHallSeats : Form
    {
        User User { get; set; }
        Form FormNavigation { get; set; }

        Movie Movie { get; set; }
        Projection Projection { get; set; }
        public FormHallSeats(Form formNavigation, User user, Movie movie, Projection projection)
        {
            InitializeComponent();
            Projection = projection;
            User = user;
            Movie = movie;
            FormNavigation = formNavigation;
            DoubleBuffered = true;

            this.SuspendLayout();
            DrawSeats();
            this.ResumeLayout(false);
        }

        private void DrawSeats()
        {
            HallService hs = new HallService(labelStatus);
            Hall hall = hs.GetHallById(Projection.IdHall);
           
            for (int r = 0; r < hall.RowCount; r++)
            {
                for(int c = 0; c < hall.ColumnCount; c++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(64 + c*32, 30+r*47);
                    pictureBox.Size = new Size(32, 32);
                    pictureBox.BackColor = Color.Transparent;
                    pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("chair_white");
                    //pictureBox.Visible = false;
                    this.Controls.Add(pictureBox);
                }
            }
            
            /*
            foreach (Control control in this.Controls)
            {
                if(control is PictureBox pictureBox)
                {
                    pictureBox.Visible = true;
                }
            }
            */
        }
    }
}
