using Kino.model;
using Kino.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kino.view
{
    /// <summary>
    /// The FormProjections class represents a Windows Form for managing and displaying movie projections in a cinema. 
    /// It provides functionality to view, filter, and delete projections. The form also allows users to view detailed 
    /// information about projections, such as available seats, and navigate to related forms for seat reservations.
    /// </summary>
    public partial class FormProjections : Form
    {
        User User { get; set; } // user currently logged in
        Form FormNavigation { get; set; } // parent form used for navigation and loading child forms

        public DateTime selectedDate; // date selected by the user to filter projections

        public bool datePicked; // boolean value indicating whether a date has been selected by the user

        /// <summary>
        /// Constructor for FormProjections.
        /// Initializes the form by setting up UI components, filling data for halls, and preparing the form for interaction.
        /// This includes setting default states for the date picker, filter button, and loading available halls into a combo box.
        /// </summary>
        public FormProjections(Form formNavigation, User user)
        {
            InitializeComponent();
            User = user;
            FormNavigation = formNavigation;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;
            DoubleBuffered = true;

            labelStatus.Text = "";
            datePicked = false;

            dateTimePickerDate.CustomFormat = " ";
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            buttonFilter.Enabled = false;

            HallService hallService = new HallService(labelStatus);
            List<Hall> halls = hallService.GetHalls();

            comboBoxHallFilter.Items.Clear();

            comboBoxHallFilter.DataSource = halls;
            comboBoxHallFilter.DisplayMember = "IdHall";
            comboBoxHallFilter.ValueMember = "IdHall";
            comboBoxHallFilter.Text = "Select a hall...";
            comboBoxHallFilter.SelectedIndex = -1;

            FillData();
        }

        /// <summary>
        /// Fills the data grid with all the projections from the database without applying any filters.
        /// This method retrieves all available projections and related movie data and then displays them in the grid view.
        /// </summary>
        private void FillData()
        {
            dataGridViewProjections.Rows.Clear();

            ProjectionService projectionService = new ProjectionService(labelStatus);
            List<Projection> projections = projectionService.GetProjections();

            MovieService movieService = new MovieService(labelStatus);
            ReservationService rs = new ReservationService(labelStatus);

            foreach (Projection projection in projections)
            {
                Movie movie = movieService.GetMovieById(projection.IdMovie);
                dataGridViewProjections.Rows.Add(false, movie.NameMovie, projection.Date.ToString("dd.MM.yyyy"), projection.Time, projection.IdHall, rs.GetNumberOfReservationsByProjectionId(projection.IdProjection), getNumberOfFreeSeats(projection), "view");
            }
        }

        /// <summary>
        /// Filters projections by the selected date and updates the data grid with the relevant data.
        /// </summary>
        private void FillDataFilterDate()
        {
            dataGridViewProjections.Rows.Clear();

            ProjectionService projectionService = new ProjectionService(labelStatus);
            List<Projection> projections = projectionService.GetProjectionsByDate(selectedDate);

            MovieService movieService = new MovieService(labelStatus);
            ReservationService rs = new ReservationService(labelStatus);

            if(projections != null)
            {
                foreach (Projection projection in projections)
                {
                    Movie movie = movieService.GetMovieById(projection.IdMovie);
                    dataGridViewProjections.Rows.Add(false, movie.NameMovie, projection.Date.ToString("dd.MM.yyyy"), projection.Time, projection.IdHall, rs.GetNumberOfReservationsByProjectionId(projection.IdProjection), getNumberOfFreeSeats(projection), "view");
                }
            }
        }

        /// <summary>
        /// Filters projections by both selected hall and date, then updates the data grid.
        /// </summary>
        private void FillDataFilterHallDate()
        {
            dataGridViewProjections.Rows.Clear();

            ProjectionService projectionService = new ProjectionService(labelStatus);
            List<Projection> projections = projectionService.GetProjectionsByHallDate(selectedDate, (int)comboBoxHallFilter.SelectedValue);

            MovieService movieService = new MovieService(labelStatus);
            ReservationService rs = new ReservationService(labelStatus);

            if (projections != null) // bez ovog exception
            {
                foreach (Projection projection in projections)
                {
                    Movie movie = movieService.GetMovieById(projection.IdMovie);
                    dataGridViewProjections.Rows.Add(false, movie.NameMovie, projection.Date.ToString("dd.MM.yyyy"), projection.Time, projection.IdHall, rs.GetNumberOfReservationsByProjectionId(projection.IdProjection), getNumberOfFreeSeats(projection), "view");
                }
            }
        }

        /// <summary>
        /// Filters projections based only on the selected hall and updates the data grid.
        /// </summary>
        private void FillDataFilterHall()
        {
            dataGridViewProjections.Rows.Clear();

            ProjectionService projectionService = new ProjectionService(labelStatus);
            List<Projection> projections = projectionService.GetProjectionByHallId((int)comboBoxHallFilter.SelectedValue);

            MovieService movieService = new MovieService(labelStatus);
            ReservationService rs = new ReservationService(labelStatus);

            if (projections != null) // bez ovog exception
            {
                foreach (Projection projection in projections)
                {
                    Movie movie = movieService.GetMovieById(projection.IdMovie);
                    dataGridViewProjections.Rows.Add(false, movie.NameMovie, projection.Date.ToString("dd.MM.yyyy"), projection.Time, projection.IdHall, rs.GetNumberOfReservationsByProjectionId(projection.IdProjection), getNumberOfFreeSeats(projection), "view");
                }
            }
        }

        /// <summary>
        /// Calculates and returns the number of available seats for a given projection.
        /// This is based on the hall's dimensions (columns and rows) and the number of existing reservations.
        /// </summary>
        public int getNumberOfFreeSeats(Projection projection)
        {
            HallService hs = new HallService(labelStatus);
            ReservationService rs = new ReservationService(labelStatus);

            Hall hall = hs.GetHallById(projection.IdHall);
            int numberOfReservations = rs.GetNumberOfReservationsByProjectionId(projection.IdProjection);

            return hall.ColumnCount * hall.RowCount - numberOfReservations;
        }

        /// <summary>
        /// Handles cell value changes in the projections data grid, enabling the delete button when a projection is marked for deletion.
        /// It also checks if the user has selected a projection for deletion and prepares for the deletion process.
        /// </summary>
        private void dataGridViewProjections_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ProjectionService projectionService = new ProjectionService(labelStatus);

            buttonDelete.Enabled = false;

            if (e.RowIndex >= 0 && dataGridViewProjections.Columns[e.ColumnIndex].Name == "Delete")
            {
                buttonDelete.Enabled = true;
            }

            for (int i = 0; i < dataGridViewProjections.Rows.Count; i++)
            {
                if (!dataGridViewProjections.Rows[i].IsNewRow)
                {
                    DateTime date = DateTime.Parse(dataGridViewProjections.Rows[i].Cells["PDate"].Value.ToString());
                    TimeSpan time = TimeSpan.Parse(dataGridViewProjections.Rows[i].Cells["PTime"].Value.ToString());
                    int hallID = Convert.ToInt32(dataGridViewProjections.Rows[i].Cells["CinemaHall"].Value);

                    
                    Projection projection = projectionService.GetProjectionByDateTimeHall(date, time, hallID);

                    if ((bool)dataGridViewProjections.Rows[i].Cells["Delete"].Value == true)
                    {
                        buttonDelete.Enabled = true;
                    }
                }
            } 
        }

        /// <summary>
        /// Deletes the selected projections from the database and removes the corresponding movie if no more projections exist for it.
        /// After deletion, it reloads the projection data to reflect the changes.
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ProjectionService projectionService = new ProjectionService(labelStatus);
            MovieService movieService = new MovieService(labelStatus);
            foreach (DataGridViewRow row in dataGridViewProjections.Rows)
            {
                if (!row.IsNewRow)
                {
                    DateTime date = DateTime.Parse(row.Cells["PDate"].Value.ToString());
                    TimeSpan time = TimeSpan.Parse(row.Cells["PTime"].Value.ToString());
                    int hallID = Convert.ToInt32(row.Cells["CinemaHall"].Value);

                    Projection projection = projectionService.GetProjectionByDateTimeHall(date, time, hallID);

                    if ((bool)row.Cells["Delete"].Value == true)
                    {
                        // labelStatus.Text = $"delete projection at date {date}";
                        projectionService.DeleteProjectionById(projection.IdProjection);
                        movieService.DeleteMovieIfNeeded(projection.IdMovie);
                    }
                }
            }


            buttonDelete.Enabled = false;

            FillData();
        }

        /// <summary>
        /// Handles the cell click event to navigate to the detailed view of the selected projection.
        /// It opens a new form that displays the seating chart for the selected movie and projection.
        /// </summary>
        private void dataGridViewProjections_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridViewProjections.Columns[e.ColumnIndex].Name == "Details")
            {
                ProjectionService projectionService = new ProjectionService(labelStatus);
                MovieService movieService = new MovieService(labelStatus);

                DateTime date = DateTime.Parse(dataGridViewProjections.Rows[e.RowIndex].Cells["PDate"].Value.ToString());
                TimeSpan time = TimeSpan.Parse(dataGridViewProjections.Rows[e.RowIndex].Cells["PTime"].Value.ToString());
                int hallID = Convert.ToInt32(dataGridViewProjections.Rows[e.RowIndex].Cells["CinemaHall"].Value);

                string movieTitle = dataGridViewProjections.Rows[e.RowIndex].Cells["MovieTitle"].Value.ToString();

                Projection projection = projectionService.GetProjectionByDateTimeHall(date, time, hallID);
                Movie movie = movieService.GetMovieByName(movieTitle);

                foreach (Control control in FormNavigation.Controls)
                {
                    if (control is Panel panel && panel.Name == "panelFormLoader")
                    {
                        panel.Controls.Clear();
                        FormHallSeats formHallSeats = new FormHallSeats(FormNavigation, User, movie, projection);
                        formHallSeats.FormBorderStyle = FormBorderStyle.None;
                        panel.Controls.Add(formHallSeats);
                        formHallSeats.Show();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the filter button click event. Based on the user's selection of date and hall, it calls the appropriate method
        /// to filter the projections. The method decides whether to filter by date only, by both date and hall, or just by hall.
        /// </summary>
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if(datePicked && comboBoxHallFilter.SelectedIndex == -1) // ako je odabran datum za filtriranje
            {
                FillDataFilterDate();
            }
            else if(datePicked && comboBoxHallFilter.SelectedIndex != -1)
            {
                FillDataFilterHallDate();
            }
            else if(!datePicked && comboBoxHallFilter.SelectedIndex != -1)
            {
                FillDataFilterHall();
            }
        }

        /// <summary>
        /// Handles the clear button click event. Resets the date and hall filter selections, disables the filter button,
        /// and reloads the full projection data without any filters applied.
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            datePicked = false;
            buttonFilter.Enabled = false;
            dateTimePickerDate.CustomFormat = " ";
            comboBoxHallFilter.SelectedIndex = -1;
            FillData();
        }

        /// <summary>
        /// Handles the date value change event for the date picker. When the user selects a new date, it enables the filter button,
        /// marks the date as picked, and stores the selected date for later filtering.
        /// </summary>
        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            buttonFilter.Enabled = true;
            datePicked = true;
            selectedDate = dateTimePickerDate.Value.Date;
            dateTimePickerDate.CustomFormat = "dd.MM.yyyy";
        }

        /// <summary>
        /// Handles the event when the selected index of the hall filter combo box changes. It enables the filter button if a hall 
        /// is selected, otherwise disables it when both hall and date are not selected.
        /// </summary>
        private void comboBoxHallFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHallFilter.SelectedIndex != -1)
            {
                buttonFilter.Enabled = true;
            }
            else if((comboBoxHallFilter.SelectedIndex == -1 || string.IsNullOrEmpty(comboBoxHallFilter.Text)) && !datePicked)
            {
                buttonFilter.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the event when the selected value of the hall filter combo box changes. It disables the filter button 
        /// when no hall is selected and no date is picked, and enables the button when a hall or date is selected.
        /// </summary>
        private void comboBoxHallFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((comboBoxHallFilter.SelectedIndex == -1 || string.IsNullOrEmpty(comboBoxHallFilter.Text)) && !datePicked)
            {
                buttonFilter.Enabled = false;
            }
        }
    }
}
