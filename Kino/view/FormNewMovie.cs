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
    public partial class FormNewMovie : Form
    {
        User User { get; set; }
        public FormNewMovie(User user)
        {
            InitializeComponent();
            User = user;
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDescription.Text != string.Empty && pictureBoxPoster.Image != null)
                buttonAdd.Enabled = true;
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTitle.Text != string.Empty && pictureBoxPoster.Image != null)
                buttonAdd.Enabled = true;
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPoster.Load(openFileDialog1.FileName);

                if (textBoxTitle.Text != string.Empty && textBoxDescription.Text != string.Empty)
                    buttonAdd.Enabled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MovieService movieService = new MovieService(labelStatus);

            Movie newMovie = movieService.InsertMovie(textBoxTitle.Text, textBoxDescription.Text, pictureBoxPoster.Image);

            //pictureBoxPoster.Image.Save($"movie_{newMovie.IdMovie}");

            /*
            string resourcesPath = Path.Combine(Application.StartupPath, "Resources");
            Directory.CreateDirectory(resourcesPath); // Ensure the Resources folder exists

            string imagePath = Path.Combine(resourcesPath, $"movie_{newMovie.IdMovie}.png");
            pictureBoxPoster.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
            */
        }
    }
}
