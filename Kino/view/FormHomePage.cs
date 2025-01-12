using Kino.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.view
{
    public partial class FormHomePage : Form
    {
        User User { get; set; }
        Form FormRegister { get; set; }

        Form FormNavigation { get; set; }
       
        public FormHomePage(Form formRegister, Form formNavigation, User user)
        {
            SuspendLayout();

            InitializeComponent();
            DoubleBuffered = true;
            User = user;
            FormRegister = formRegister;
            FormNavigation = formNavigation;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

            GenerateMovieLayout();
            
            ResumeLayout();
        }

        
        public void GenerateMovieLayout()
        {
            Type resourceType = typeof(Properties.Resources);

            this.Controls.Clear(); // Clear existing controls if any

            int pictureBoxWidth = 300;  // Width of each PictureBox
            int pictureBoxHeight = 410; // Height of each PictureBox
            int spacing = 20;           // Spacing between PictureBoxes
            int columns = 3;            // Number of PictureBoxes per row

            int x = spacing; // Initial X position
            int y = spacing; // Initial Y position


            MovieService movieService = new MovieService(labelStatus);

            List<Movie> movies = movieService.GetMovies();

            for (int i = 0; i < movies.Count; i++)
            { 
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(pictureBoxWidth, pictureBoxHeight),
                    Location = new Point(x, y),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = (Image)Properties.Resources.ResourceManager.GetObject($"movie_{i + 1}"),
                    Tag = i + 1,
                    BorderStyle = BorderStyle.FixedSingle
                };

                pictureBox.Click += PictureBox_Click;

                this.Controls.Add(pictureBox);

                // Positioning logic
                x += pictureBoxWidth + spacing;
                if ((i + 1) % 3 == 0)
                {
                    x = spacing;
                    y += pictureBoxHeight + spacing;
                }

            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox != null)
            {
                foreach(Control control in FormNavigation.Controls)
                {
                    if (control is Panel panel && panel.Name == "panelFormLoader")
                    {
                        panel.Controls.Clear();
                        FormOverviewProjections formOverviewProjections = new FormOverviewProjections(FormRegister, User, clickedPictureBox.Tag.ToString());
                        formOverviewProjections.FormBorderStyle = FormBorderStyle.None;
                        panel.Controls.Add(formOverviewProjections);
                        formOverviewProjections.Show();
                    }
                }
            }
        }
    }
}
