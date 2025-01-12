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
        Form FormRegister { get; set; }

        Movie Movie { get; set; }

        public FormOverviewProjections(Form formRegister, User user, string id)
        {
            InitializeComponent();
            DoubleBuffered = true;

            User = user;
            FormRegister = formRegister;
            int movieId = Int32.Parse(id);
            pictureBoxMoviePoster.Image = (Image)Properties.Resources.ResourceManager.GetObject($"movie_{movieId}");
            pictureBoxMoviePoster.SizeMode = PictureBoxSizeMode.Zoom;
            MovieService ms = new MovieService(labelStatus);
            Movie = ms.GetMovieById(movieId);

            ProjectionService ps = new ProjectionService(labelStatus);
            List<Projection> projections = new List<Projection>();
            projections = ps.GetProjectionsByMovieId(movieId);

            if(projections != null)
            {
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormRegister.Close();
        }
    }
}
