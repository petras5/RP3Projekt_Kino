using Kino.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.view
{
    /// <summary>
    /// The FormHomePage class represents the home page of the Kino application. 
    /// It displays a dynamic layout of movie posters that can be clicked to view projections for a specific movie.
    /// </summary>
    public partial class FormHomePage : Form
    {
        User User { get; set; } // user currently logged into the app

        Form FormNavigation { get; set; } // navigation form managing this home page form

        /// <summary>
        /// Constructor for FormHomePage.
        /// </summary>
        /// <param name="formNavigation">The parent navigation form.</param>
        /// <param name="user">The current user.</param>
        public FormHomePage(Form formNavigation, User user)
        {
            SuspendLayout();

            InitializeComponent();
            DoubleBuffered = true;
            User = user;
            FormNavigation = formNavigation;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

            GenerateMovieLayout();
            
            ResumeLayout();
        }

        /// <summary>
        /// Dynamically generates a layout of movie posters based on the available movies.
        /// </summary>
        public void GenerateMovieLayout()
        {
            Type resourceType = typeof(Properties.Resources); // access application resources

            this.Controls.Clear(); // Clear existing controls if any

            // Layout parameters
            int pictureBoxWidth = 300;  // Width of each PictureBox
            int pictureBoxHeight = 410; // Height of each PictureBox
            int spacing = 20;           // Spacing between PictureBoxes
            int columns = 3;            // Number of PictureBoxes per row

            int x = spacing; // Initial X position
            int y = spacing; // Initial Y position


            MovieService movieService = new MovieService(labelStatus);

            List<Movie> movies = movieService.GetMovies();
            int i = 0;

            // Create a PictureBox for each movie.
            foreach (Movie movie in movies) 
            { 
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(pictureBoxWidth, pictureBoxHeight),
                    Location = new Point(x, y),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Tag = movie.IdMovie,
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Assign the appropriate image to the PictureBox.
                if (movie.ImageData != null) {

                    pictureBox.Image = movieService.byteArrayToImage(movie.ImageData, PixelFormat.Format24bppRgb);
                }
                else
                {
                    pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject($"movie_{movie.IdMovie}");
                }

                pictureBox.Click += PictureBox_Click;

                this.Controls.Add(pictureBox);

                // Position the next PictureBox
                x += pictureBoxWidth + spacing;
                if ((i + 1) % 3 == 0)
                {
                    x = spacing; // Reset X position for a new row.
                    y += pictureBoxHeight + spacing; // Move to the next row.
                }
                i++;
            }
        }

        /// <summary>
        /// Handles the click event of a movie's PictureBox to navigate to the movie's projections.
        /// </summary>
        /// <param name="sender">The PictureBox that was clicked.</param>
        /// <param name="e">Event arguments.</param>
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
                        FormOverviewProjections formOverviewProjections = new FormOverviewProjections(FormNavigation, User, clickedPictureBox.Tag.ToString());
                        formOverviewProjections.FormBorderStyle = FormBorderStyle.None;
                        panel.Controls.Add(formOverviewProjections);
                        formOverviewProjections.Show();
                    }
                }
            }
        }
    }
}
