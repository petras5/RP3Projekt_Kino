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
    public partial class FormReceiptDetails : Form
    {
        User User { get; set; }

        Receipt Receipt { get; set; }

        public FormReceiptDetails(User user, Receipt receipt)
        {
            InitializeComponent();
            User = user;
            Receipt = receipt;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;
            DoubleBuffered = true;
            GetReceiptDetails();
        }

        private void GetReceiptDetails()
        {
            ReservationService rs = new ReservationService(labelStatus);
            ProjectionService ps = new ProjectionService(labelStatus);
            MovieService ms = new MovieService(labelStatus);
            UserService us = new UserService(labelStatus);

            User user = us.GetUserById(Receipt.IdUser);
            labelReceiptDetails.Text = "RECEIPT #" + Receipt.IdReceipt + System.Environment.NewLine
                + System.Environment.NewLine;

            List<Reservation> reservations = rs.GetReservationsByReceiptId(Receipt.IdReceipt);
            if (reservations != null)
            {
                Projection projection = ps.GetProjectionById(reservations[0].IdProjection);
                if (projection != null)
                {
                    Movie movie = ms.GetMovieById(projection.IdMovie);
                    if (movie != null)
                    {
                        labelReceiptDetails.Text += "Movie: " + movie.NameMovie + System.Environment.NewLine
                            + "Date: " + projection.Date.ToString("dd.MM.yyyy") + System.Environment.NewLine
                            + "Time: " + projection.Time + System.Environment.NewLine
                            + System.Environment.NewLine;
                    }
                }
                labelReceiptDetails.Text += "TICKETS: " + System.Environment.NewLine;
                foreach (Reservation reservation in reservations)
                {
                    labelReceiptDetails.Text += "Row " + reservation.Row + " Seat " + reservation.Column
                        + " Price: " + reservation.Price + System.Environment.NewLine;
                }
                labelReceiptDetails.Text += "----------------------------------------------" + System.Environment.NewLine;
                labelReceiptDetails.Text += "TOTAL PRICE: " + Receipt.Total + System.Environment.NewLine
                    + System.Environment.NewLine
                    + "Created: " + Receipt.Created + System.Environment.NewLine
                    + "Employee: " + user.Name + " " + user.Surname + System.Environment.NewLine;
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(labelReceiptDetails.Text, new Font("Times New Romans", 20, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void DeleteReceipt()
        {
            ReceiptService rs = new ReceiptService(labelStatus);
            rs.DeleteReceiptById(Receipt.IdReceipt);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                DeleteReceipt();
            }
            else
            {
                MessageBox.Show("Delete operation canceled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
