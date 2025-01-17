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
    public partial class FormProjections : Form
    {
        User User { get; set; }
        Form FormNavigation { get; set; }

        public DateTime selectedDate;

        public bool datePicked;
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

        private void FillDataFilterDate()
        {
            dataGridViewProjections.Rows.Clear();

            ProjectionService projectionService = new ProjectionService(labelStatus);
            List<Projection> projections = projectionService.GetProjectionsByDate(selectedDate);

            MovieService movieService = new MovieService(labelStatus);
            ReservationService rs = new ReservationService(labelStatus);

            if(projections != null) // bez ovog exception
            {
                foreach (Projection projection in projections)
                {
                    Movie movie = movieService.GetMovieById(projection.IdMovie);
                    dataGridViewProjections.Rows.Add(false, movie.NameMovie, projection.Date.ToString("dd.MM.yyyy"), projection.Time, projection.IdHall, rs.GetNumberOfReservationsByProjectionId(projection.IdProjection), getNumberOfFreeSeats(projection), "view");
                }
            }
        }

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

        public int getNumberOfFreeSeats(Projection projection)
        {
            HallService hs = new HallService(labelStatus);
            ReservationService rs = new ReservationService(labelStatus);

            Hall hall = hs.GetHallById(projection.IdHall);
            int numberOfReservations = rs.GetNumberOfReservationsByProjectionId(projection.IdProjection);

            return hall.ColumnCount * hall.RowCount - numberOfReservations;
        }

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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ProjectionService projectionService = new ProjectionService(labelStatus);
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
                        //labelStatus.Text = $"delete projection at date {date}";
                        projectionService.DeleteProjectionById(projection.IdProjection);
                    }
                }
            }

            buttonDelete.Enabled = false;

            FillData();
        }

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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            datePicked = false;
            buttonFilter.Enabled = false;
            dateTimePickerDate.CustomFormat = " ";
            comboBoxHallFilter.SelectedIndex = -1;
            FillData();
        }

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            buttonFilter.Enabled = true;
            datePicked = true;
            selectedDate = dateTimePickerDate.Value.Date;
            dateTimePickerDate.CustomFormat = "dd.MM.yyyy";
        }

        private void comboBoxHallFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHallFilter.SelectedIndex != -1)
            {
                buttonFilter.Enabled = true;
            }
            else if((comboBoxHallFilter.SelectedIndex == -1 || string.IsNullOrEmpty(comboBoxHallFilter.Text)) && !datePicked)
            {
                //labelStatus.Text = "bla";
                buttonFilter.Enabled = false;
            }
        }

        private void comboBoxHallFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((comboBoxHallFilter.SelectedIndex == -1 || string.IsNullOrEmpty(comboBoxHallFilter.Text)) && !datePicked)
            {
                //labelStatus.Text = "blabla";
                buttonFilter.Enabled = false;
            }
        }
    }
}
