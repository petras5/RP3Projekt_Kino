using Kino.model;
using Kino.services;
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
    public partial class FormOverviewProjections : Form
    {

        User User { get; set; }
        Form FormNavigation { get; set; }
        Movie Movie { get; set; }
        List<Projection> Projections { get; set; }

        public FormOverviewProjections(Form formNavigation, User user, string id)
        {
            InitializeComponent();
            DoubleBuffered = true;

            User = user;
            FormNavigation = formNavigation;

            int movieId = Int32.Parse(id);
            pictureBoxMoviePoster.Image = (Image)Properties.Resources.ResourceManager.GetObject($"movie_{movieId}");
            pictureBoxMoviePoster.SizeMode = PictureBoxSizeMode.Zoom;
            MovieService ms = new MovieService(labelStatus);
            Movie = ms.GetMovieById(movieId);

            ProjectionService ps = new ProjectionService(labelStatus);
            List<Projection> projections = new List<Projection>();
            projections = ps.GetProjectionsByMovieId(movieId);
            Projections = projections;

            if(projections != null)
            {
                dataGridViewProjections.SelectionChanged -= new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
                foreach (Projection projection in projections)
                {
                    dataGridViewProjections.Rows.Add(new object[]
                    {
                    projection.Date,
                    projection.Time,
                    projection.IdHall,
                    getNumberOfFreeSeats(projection)
                    }
                    );
                }
                dataGridViewProjections.ClearSelection();
                dataGridViewProjections.SelectionChanged += new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
            } else
            {
                dataGridViewProjections.Visible = false;
                labelStatus.Text = "COMING SOON";
                labelStatus.ForeColor = Color.White;
                labelStatus.Font = new Font("Berlin Sans FB", 18);

            }

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

            labelMovieName.Text = Movie.NameMovie;
            labelDescription.Text = Movie.Description;
            //labelStatus.Text = $"Movie with index {movieId}";
        }

        public int getNumberOfFreeSeats(Projection projection)
        {
            HallService hs = new HallService(labelStatus);
            ReservationService rs = new ReservationService(labelStatus);

            Hall hall = hs.GetHallById(projection.IdHall);
            int numberOfReservations = rs.GetNumberOfReservationsByProjectionId(projection.IdProjection);

            return hall.ColumnCount * hall.RowCount - numberOfReservations;
        }

        private void dataGridViewProjections_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProjections.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewProjections.SelectedRows[0].Index;
                labelStatus.Text = $"Selected Row Index: {rowIndex}";
                if(Projections != null)
                {
                    labelStatus.Text += "Selected projection: movie id: " + Projections[rowIndex].IdMovie
                    + ", date: " + Projections[rowIndex].Date
                    + " time: " + Projections[rowIndex].Time
                    + " hall: " + Projections[rowIndex].IdHall
                    + " count: " + dataGridViewProjections.SelectedRows.Count;
                    foreach (Control control in FormNavigation.Controls)
                    {
                        if (control is Panel panel && panel.Name == "panelFormLoader")
                        {
                            panel.Controls.Clear();
                            FormHallSeats formHallSeats = new FormHallSeats(FormNavigation, User, Movie, Projections[rowIndex]);
                            formHallSeats.TopLevel = false; // Necessary to embed a Form into a Panel.
                            formHallSeats.Dock = DockStyle.Fill; 
                            panel.Controls.Add(formHallSeats);
                            formHallSeats.Show(); 
                        }
                    }
                }
            }
        }
    }
}
