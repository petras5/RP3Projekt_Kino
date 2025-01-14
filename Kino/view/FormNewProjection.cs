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
    public partial class FormNewProjection : Form
    {
        User User { get; set; }
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

        public void FillData()
        {
            MovieService movieService = new MovieService(labelStatus);
            List<Movie> movies = movieService.GetMovies();

            HallService hallService = new HallService(labelStatus);
            List<Hall> halls = hallService.GetHalls();

            comboBoxMovies.Items.Clear();
            /*
            foreach (Movie movie in movies)
            {
                comboBoxMovies.Items.Add(new { movie.IdMovie, movie.NameMovie });
                comboBoxMovies.ValueMember = movie.IdMovie.ToString();
                comboBoxMovies.DisplayMember = movie.NameMovie;
                
            }
            */
            //comboBoxMovies.Items.Add(movie.NameMovie);
            //comboBox

            comboBoxMovies.DataSource = movies;
            comboBoxMovies.DisplayMember = "NameMovie";
            comboBoxMovies.ValueMember = "IdMovie";
            comboBoxMovies.Text = "Select a movie...";
            comboBoxMovies.SelectedIndex = -1;

            comboBoxHalls.Items.Clear();
            foreach (Hall hall in halls)
                comboBoxHalls.Items.Add(hall.IdHall);
        }

        //slucajno dodano...
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHalls.SelectedIndex != -1)
            {
                buttonAdd.Enabled = true;
                labelStatus.Text = comboBoxMovies.SelectedValue.ToString();
            }
                

            
        }

        private void comboBoxHalls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMovies.SelectedIndex != -1)
                buttonAdd.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProjectionService projectionService = new ProjectionService(labelStatus);

            //DateTime dt = dateTimePickerTime.Value;
            //TimeSpan st = new Timespan(dt.Hour, dt.Minute, dt.Second);
            MovieService movieService = new MovieService(labelStatus);

            
            /*
            if (projectionService.CheckCollision((int)comboBoxHalls.SelectedValue, monthCalendarDate.SelectionStart, dateTimePickerTime.Value.TimeOfDay))
            {
                Projection newProjection = 
                    projectionService.InsertNewProjection(
                                        (int)comboBoxHalls.SelectedValue,
                                        comboBoxMovies.SelectedValue.,
                    );
            }
            */
        }
    }
}
