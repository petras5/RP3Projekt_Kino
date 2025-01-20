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
    /// <summary>
    /// Represents the form for displaying an overview of projections for a specific movie.
    /// </summary>
    public partial class FormOverviewProjections : Form
    {
        User User { get; set; } // currently logged-in user
        Form FormNavigation { get; set; } // navigation form managing this form
        Movie Movie { get; set; } // movie associated with the projections

        public DateTime selectedDate; // selected date for filtering projections

        /// <summary>
        /// Constructor for FormOverviewProjections.
        /// </summary>
        /// <param name="formNavigation">The navigation form that contains this form.</param>
        /// <param name="user">The currently logged-in user. </param>
        /// <param name="id">The ID of the movie for which projections are being displayed.</param>
        public FormOverviewProjections(Form formNavigation, User user, string id)
        {
            InitializeComponent();
            DoubleBuffered = true;

            User = user;
            FormNavigation = formNavigation;

            int movieId = Int32.Parse(id);
            MovieService ms = new MovieService(labelStatus);
            Movie = ms.GetMovieById(movieId);

            // Set up the DateTimePicker for selecting a date.
            dateTimePickerDate.CustomFormat = " ";
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            buttonFilter.Enabled = false;

            // Load the movie poster image.
            if (Movie.ImageData != null)
            {

                pictureBoxMoviePoster.Image = ms.byteArrayToImage(Movie.ImageData, PixelFormat.Format24bppRgb);
            }
            else
            {
                pictureBoxMoviePoster.Image = (Image)Properties.Resources.ResourceManager.GetObject($"movie_{movieId}");
            }
            pictureBoxMoviePoster.SizeMode = PictureBoxSizeMode.Zoom;

            // Retrieve and display the projections for the movie.
            ProjectionService ps = new ProjectionService(labelStatus);
            List<Projection> projections = new List<Projection>();
            projections = ps.GetProjectionsByMovieId(movieId);

            ReservationService rs = new ReservationService(labelStatus);

            // If projections are found, display them in the DataGridView.
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
                // If no projections, display a "Coming Soon" message.
                dataGridViewProjections.Visible = false;
                dateTimePickerDate.Visible = false;
                buttonClear.Visible = false;
                buttonFilter.Visible = false;
                labelStatus.Text = "COMING SOON";
                labelStatus.ForeColor = Color.White;
                labelStatus.Font = new Font("Berlin Sans FB", 18);

            }

            // Set the form's docking and visibility properties.
            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

            // Set the movie's name and description labels.
            labelMovieName.Text = Movie.NameMovie;
            labelDescription.Text = Movie.Description;
            //labelStatus.Text = $"Movie with index {movieId}";
        }

        /// <summary>
        /// Retrieves the number of free seats available for the given projection.
        /// </summary>
        /// <param name="projection">The projection for which to calculate available seats.</param>
        /// <returns>The number of free seats for the projection.</returns>
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
        }

        /// <summary>
        /// Handles the event when a cell in the projections DataGridView is clicked.
        /// Opens the hall seats form for the selected projection.
        /// </summary>
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

        /// <summary>
        /// Handles the event when the filter button is clicked to filter projections by the selected date.
        /// </summary>
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

        /// <summary>
        /// Handles the event when the clear button is clicked to reset the filter and show all projections.
        /// </summary>
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

        /// <summary>
        /// Handles the event when the value of the date picker changes.
        /// Enables the filter button and updates the selected date.
        /// </summary>
        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            buttonFilter.Enabled = true;
            selectedDate = dateTimePickerDate.Value.Date;
            dateTimePickerDate.CustomFormat = "dd.MM.yyyy";
        }
    }
}
