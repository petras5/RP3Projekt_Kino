using Kino.model;
using Kino.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        public DateTime selectedDate;

        public FormOverviewProjections(Form formNavigation, User user, string id)
        {
            InitializeComponent();
            DoubleBuffered = true;

            User = user;
            FormNavigation = formNavigation;

            int movieId = Int32.Parse(id);
            MovieService ms = new MovieService(labelStatus);
            Movie = ms.GetMovieById(movieId);

            dateTimePickerDate.CustomFormat = " ";
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            buttonFilter.Enabled = false;

            if (Movie.ImageData != null)
            {

                pictureBoxMoviePoster.Image = ms.byteArrayToImage(Movie.ImageData, PixelFormat.Format24bppRgb);
            }
            else
            {
                pictureBoxMoviePoster.Image = (Image)Properties.Resources.ResourceManager.GetObject($"movie_{movieId}");
            }
            pictureBoxMoviePoster.SizeMode = PictureBoxSizeMode.Zoom;
            ProjectionService ps = new ProjectionService(labelStatus);
            List<Projection> projections = new List<Projection>();
            projections = ps.GetProjectionsByMovieId(movieId);

            ReservationService rs = new ReservationService(labelStatus);

            if (projections != null)
            {
                dataGridViewProjections.SelectionChanged -= new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
                foreach (Projection projection in projections)
                {
                    dataGridViewProjections.Rows.Add(
                    projection.Date,
                    projection.Time,
                    projection.IdHall,
                    rs.GetNumberOfReservationsByProjectionId(projection.IdProjection),
                    getNumberOfFreeSeats(projection)
                    );
                }
                dataGridViewProjections.ClearSelection();
                dataGridViewProjections.SelectionChanged += new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
            } else
            {
                dataGridViewProjections.Visible = false;
                dateTimePickerDate.Visible = false;
                buttonClear.Visible = false;
                buttonFilter.Visible = false;
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
            /*
            if (dataGridViewProjections.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewProjections.SelectedRows[0].Index;

                // Ignore header selection
                if (rowIndex < 0)
                {
                    labelStatus.Text = "Header row selected; no action performed.";
                    return;
                }

                labelStatus.Text = $"Selected Row Index: {rowIndex}";

                if (Projections != null)
                {
                    labelStatus.Text += " Selected projection: movie id: " + Projections[rowIndex].IdMovie
                                        + ", date: " + Projections[rowIndex].Date
                                        + ", time: " + Projections[rowIndex].Time
                                        + ", hall: " + Projections[rowIndex].IdHall
                                        + ", count: " + dataGridViewProjections.SelectedRows.Count;

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
            */
        }

        private void dataGridViewProjections_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProjections.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                int rowIndex = dataGridViewProjections.SelectedRows[0].Index;
                labelStatus.Text = $"Selected Row Index: {rowIndex}";

                DateTime date = DateTime.Parse(dataGridViewProjections.Rows[e.RowIndex].Cells["ColumnDate"].Value.ToString());
                TimeSpan time = TimeSpan.Parse(dataGridViewProjections.Rows[e.RowIndex].Cells["ColumnTime"].Value.ToString());
                int hallID = Convert.ToInt32(dataGridViewProjections.Rows[e.RowIndex].Cells["ColumnHall"].Value);

                ProjectionService ps = new ProjectionService(labelStatus);
                Projection projection = ps.GetProjectionByDateTimeHall(date, time, hallID);
                if (projection != null)
                {
                    labelStatus.Text += "Selected projection: movie id: " + projection.IdMovie
                    + ", date: " + projection.Date
                    + " time: " + projection.Time
                    + " hall: " + projection.IdHall
                    + " count: " + dataGridViewProjections.SelectedRows.Count;
                    foreach (Control control in FormNavigation.Controls)
                    {
                        if (control is Panel panel && panel.Name == "panelFormLoader")
                        {
                            panel.Controls.Clear();
                            FormHallSeats formHallSeats = new FormHallSeats(FormNavigation, User, Movie, projection);
                            formHallSeats.TopLevel = false; // Necessary to embed a Form into a Panel.
                            formHallSeats.Dock = DockStyle.Fill;
                            panel.Controls.Add(formHallSeats);
                            formHallSeats.Show();
                        }
                    }
                }
            }

        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            dataGridViewProjections.Rows.Clear();
            ProjectionService projectionService = new ProjectionService(labelStatus);
            List<Projection> projections = projectionService.GetProjectionsByMovieDate(selectedDate, Movie.IdMovie);
            ReservationService reservationService = new ReservationService(labelStatus);
            if (projections != null)
            {
                dataGridViewProjections.SelectionChanged -= new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
                foreach (Projection projection in projections)
                {
                    dataGridViewProjections.Rows.Add(
                    projection.Date,
                    projection.Time,
                    projection.IdHall,
                    reservationService.GetNumberOfReservationsByProjectionId(projection.IdProjection),
                    getNumberOfFreeSeats(projection)
                    );
                }
                dataGridViewProjections.ClearSelection();
                dataGridViewProjections.SelectionChanged += new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            buttonFilter.Enabled = false;
            dateTimePickerDate.CustomFormat = " ";

            dataGridViewProjections.Rows.Clear();
            ProjectionService projectionService = new ProjectionService(labelStatus);
            List<Projection> projections = projectionService.GetProjectionsByMovieId(Movie.IdMovie);
            ReservationService reservationService = new ReservationService(labelStatus);
            if (projections != null)
            {
                dataGridViewProjections.SelectionChanged -= new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
                foreach (Projection projection in projections)
                {
                    dataGridViewProjections.Rows.Add(
                    projection.Date,
                    projection.Time,
                    projection.IdHall,
                    reservationService.GetNumberOfReservationsByProjectionId(projection.IdProjection),
                    getNumberOfFreeSeats(projection)
                    );
                }
                dataGridViewProjections.ClearSelection();
                dataGridViewProjections.SelectionChanged += new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
            }
        }

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            buttonFilter.Enabled = true;
            selectedDate = dateTimePickerDate.Value.Date;
            dateTimePickerDate.CustomFormat = "dd.MM.yyyy";
        }
    }
}
