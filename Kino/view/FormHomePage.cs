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
                //string resourceName = $"movie_{i + 1}.jpg"; // Dynamically construct the resource name
                //PropertyInfo resourceProperty = resourceType.GetProperty(resourceName, BindingFlags.Static | BindingFlags.Public);

                //if (resourceProperty != null)
                {
                    //Image resourceImage = (Image)resourceProperty.GetValue(null);

                    PictureBox pictureBox = new PictureBox
                    {
                        Size = new Size(pictureBoxWidth, pictureBoxHeight),
                        Location = new Point(x, y),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        /*Image = resourceImage,*/
                        /*Image = Image.FromFile
   (System.Environment.GetFolderPath
   (System.Environment.SpecialFolder.MyPictures)
   + $"movie_{i+1}.jpg"),*/
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
                //else
                {
                    //MessageBox.Show($"Resource '{resourceName}' not found in Properties.Resources.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Get the clicked PictureBox
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


                /*
                // Access the image or other data (e.g., from the Tag property)
                int index = (int)clickedPictureBox.Tag;
                MessageBox.Show($"You clicked on PictureBox with index {index}.", "PictureBox Clicked");

                // Example: Open the image in a new form or perform other actions
                Form imageForm = new Form
                {
                    Size = new Size(800, 600),
                    BackgroundImage = clickedPictureBox.Image,
                    BackgroundImageLayout = ImageLayout.Zoom
                };
                imageForm.Show();
                */


            }
        }


    }
}
