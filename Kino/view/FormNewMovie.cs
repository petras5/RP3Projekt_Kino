using Kino.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.view
{
    /// <summary>
    /// Represents the form where a user can add a new movie, including title, description, and poster image.
    /// </summary>
    public partial class FormNewMovie : Form
    {
        User User { get; set; } // currently logged-in user

        /// <summary>
        /// Constructor for FormNewMovie.
        /// </summary>
        /// <param name="user">The currently logged-in user.</param>
        public FormNewMovie(User user)
        {
            InitializeComponent();
            User = user;
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;
        }

        /// <summary>
        /// Handles the event when the title text changes.
        /// Enables or disables the Add button based on the form's input fields.
        /// </summary>
        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTitle.Text != string.Empty && textBoxDescription.Text != string.Empty && pictureBoxPoster.Image != null)
                buttonAdd.Enabled = true;
            if(textBoxTitle.Text == string.Empty)
                buttonAdd.Enabled= false;
        }

        /// <summary>
        /// Handles the event when the description text changes.
        /// Enables or disables the Add button based on the form's input fields.
        /// </summary>
        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDescription.Text != string.Empty && textBoxTitle.Text != string.Empty && pictureBoxPoster.Image != null)
                buttonAdd.Enabled = true;
            if (textBoxDescription.Text == string.Empty)
                buttonAdd.Enabled = false;
        }

        /// <summary>
        /// Handles the event when the user clicks the Choose button to select a poster image.
        /// Opens a file dialog for the user to select an image.
        /// </summary>
        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPoster.Load(openFileDialog1.FileName);

                if (textBoxTitle.Text != string.Empty && textBoxDescription.Text != string.Empty)
                    buttonAdd.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the event when the user clicks the Add button to add a new movie.
        /// Checks if the movie already exists and adds it if it doesn't.
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MovieService movieService = new MovieService(labelStatus);

            if (movieService.GetMovieByName(textBoxTitle.Text) != null)
            {
                labelStatus.Text = "Movie with that name already exists.";
            }
            else
            {
                Movie newMovie = movieService.InsertMovie(textBoxTitle.Text, textBoxDescription.Text, pictureBoxPoster.Image);
            }

            buttonAdd.Enabled = false;
            textBoxTitle.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            pictureBoxPoster.Image = null;
        }
    }
}
