using Kino.model;
using Kino.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.view
{
    /// <summary>
    /// Represents the form where a user can add a new movie projection to the system, including the movie, hall, time, and price.
    /// </summary>
    public partial class FormNewProjection : Form
    {
        User User { get; set; } // currently logged-in user

        /// <summary>
        /// Constructor for FormNewProjection.
        /// </summary>
        /// <param name="user">The currently logged-in user.</param>
        public FormNewProjection(User user)
        {
            InitializeComponent();
            User = user;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;
            DoubleBuffered = true;

            dateTimePickerTime.ShowUpDown = true;

            FillData();
        }

        /// <summary>
        /// Fills the data for available movies and halls into the respective combo boxes.
        /// </summary>
        public void FillData()
        {
            MovieService movieService = new MovieService(labelStatus);
            List<Movie> movies = movieService.GetMovies();

            HallService hallService = new HallService(labelStatus);
            List<Hall> halls = hallService.GetHalls();

            comboBoxMovies.Items.Clear();

            comboBoxMovies.DataSource = movies;
            comboBoxMovies.DisplayMember = "NameMovie";
            comboBoxMovies.ValueMember = "IdMovie";
            comboBoxMovies.Text = "Select a movie...";
            comboBoxMovies.SelectedIndex = -1;

            comboBoxHalls.Items.Clear();

            comboBoxHalls.DataSource = halls;
            comboBoxHalls.DisplayMember = "IdHall";
            comboBoxHalls.ValueMember = "IdHall";
            comboBoxHalls.Text = "Select a hall...";
            comboBoxHalls.SelectedIndex = -1;

        }

        /// <summary>
        /// Handles the event when the selected movie changes.
        /// Enables the Add button if both movie and hall are selected.
        /// </summary>
        private void comboBoxMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHalls.SelectedIndex != -1 && comboBoxMovies.SelectedValue != null && comboBoxHalls.SelectedValue != null)
            {
                buttonAdd.Enabled = true;
                labelStatus.Text = comboBoxMovies.SelectedValue.ToString();
            }

        }

        /// <summary>
        /// Handles the event when the selected hall changes.
        /// Enables the Add button if both hall and movie are selected.
        /// </summary>
        private void comboBoxHalls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMovies.SelectedIndex != -1 && comboBoxHalls.SelectedValue != null && comboBoxMovies.SelectedValue != null)
                buttonAdd.Enabled = true;
        }

        /// <summary>
        /// Handles the event when the Add button is clicked.
        /// Adds a new projection with the selected movie, hall, time, and price
        /// if there is no collision with another projection in database.
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProjectionService projectionService = new ProjectionService(labelStatus);

            DateTime dt = dateTimePickerTime.Value;
            TimeSpan time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            DateTime date = monthCalendarDate.SelectionStart;

            if (projectionService.CheckCollision((int)comboBoxHalls.SelectedValue, date, time))
            {
                Projection newProjection = 
                    projectionService.InsertNewProjection(
                                        (int)comboBoxHalls.SelectedValue,
                                        (int)comboBoxMovies.SelectedValue,
                                        date,
                                        time,
                                        (int)numericUpDownPrice.Value
                    );
                buttonAdd.Enabled = false;
                comboBoxHalls.SelectedIndex = -1;
                comboBoxMovies.SelectedIndex = -1;
                dateTimePickerTime.Value = DateTime.Now;
                monthCalendarDate.SelectionStart = DateTime.Now.Date;
                numericUpDownPrice.Value = 10;
            }
            
        }

        /// <summary>
        /// Handles the event when the date selection changes in the calendar.
        /// Enables the Add button if both movie and hall are selected.
        /// </summary>
        private void monthCalendarDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (comboBoxMovies.SelectedValue != null && comboBoxHalls.SelectedValue != null)
            {
                buttonAdd.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the event when the time value in the DateTimePicker changes.
        /// Enables the Add button if both movie and hall are selected.
        /// </summary>
        private void dateTimePickerTime_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxMovies.SelectedValue != null && comboBoxHalls.SelectedValue != null)
            {
                buttonAdd.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the event when the price value changes in the numeric up-down control.
        /// Enables the Add button if both movie and hall are selected.
        /// </summary>
        private void numericUpDownPrice_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxMovies.SelectedValue != null && comboBoxHalls.SelectedValue != null)
            {
                buttonAdd.Enabled = true;
            }
        }
    }
}
