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
    /// This form handles displaying and printing the details of a receipt, including the list of reservations,
    /// the movie information, and the total price. It also provides the option to delete the receipt.
    /// </summary>
    public partial class FormReceiptDetails : Form
    {
        User User { get; set; } // The currently logged-in user

        Receipt Receipt { get; set; } // The receipt object whose details will be displayed

        /// <summary>
        /// Constructor for FormReceiptDetails.
        /// Initializes the form with the provided user and receipt details.
        /// </summary>
        /// <param name="user">The user who is viewing the receipt.</param>
        /// <param name="receipt">The receipt to display details for.</param>
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

        /// <summary>
        /// Retrieves and displays the details of the selected receipt, including reservations and movie information.
        /// </summary>
        private void GetReceiptDetails()
        {
            // Services for handling reservations, projections, movies, and users
            ReservationService rs = new ReservationService(labelStatus);
            ProjectionService ps = new ProjectionService(labelStatus);
            MovieService ms = new MovieService(labelStatus);
            UserService us = new UserService(labelStatus);

            // Retrieve the user who created the receipt
            User user = us.GetUserById(Receipt.IdUser);

            // Start building the receipt details display
            labelReceiptDetails.Text = "RECEIPT #" + Receipt.IdReceipt + System.Environment.NewLine
                + System.Environment.NewLine;

            // Get all reservations for this receipt
            List<Reservation> reservations = rs.GetReservationsByReceiptId(Receipt.IdReceipt);
            if (reservations != null)
            {
                // Get the projection associated with the reservations
                Projection projection = ps.GetProjectionById(reservations[0].IdProjection);
                if (projection != null)
                {
                    // Get the movie associated with the projection
                    Movie movie = ms.GetMovieById(projection.IdMovie);
                    if (movie != null)
                    {
                        // Display movie, date, and time information
                        labelReceiptDetails.Text += "Movie: " + movie.NameMovie + System.Environment.NewLine
                            + "Date: " + projection.Date.ToString("dd.MM.yyyy") + System.Environment.NewLine
                            + "Time: " + projection.Time + System.Environment.NewLine
                            + System.Environment.NewLine;
                    }
                }
                // Display reservation details (row, seat, and price)
                labelReceiptDetails.Text += "TICKETS: " + System.Environment.NewLine;
                foreach (Reservation reservation in reservations)
                {
                    labelReceiptDetails.Text += "Row " + reservation.Row + " Seat " + reservation.Column
                        + " Price: " + reservation.Price + System.Environment.NewLine;
                }
                // Display total price and receipt creation details
                labelReceiptDetails.Text += "----------------------------------------------" + System.Environment.NewLine;
                labelReceiptDetails.Text += "TOTAL PRICE: " + Receipt.Total + System.Environment.NewLine
                    + System.Environment.NewLine
                    + "Created: " + Receipt.Created + System.Environment.NewLine
                    + "Employee: " + user.Name + " " + user.Surname + System.Environment.NewLine;
            }

        }

        /// <summary>
        /// Handles the printing of the receipt details when the print preview dialog is initiated.
        /// </summary>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(labelReceiptDetails.Text, new Font("Times New Romans", 20, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
        }

        /// <summary>
        /// Handles the print button click event. It shows the print preview dialog and initiates the printing process if the user confirms.
        /// </summary>
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // Show the print preview dialog and initiate printing if the user confirms
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        /// <summary>
        /// Deletes the current receipt from the system.
        /// </summary>
        private void DeleteReceipt()
        {
            ReceiptService rs = new ReceiptService(labelStatus);
            rs.DeleteReceiptById(Receipt.IdReceipt);
        }

        /// <summary>
        /// Handles the delete button click event. Asks the user to confirm before deleting the receipt.
        /// If the user confirms, the receipt is deleted from the system.
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Prompt the user for confirmation before deleting the receipt
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // Proceed based on the user's choice
            if (result == DialogResult.Yes)
            {
                DeleteReceipt();
            }
            else
            {
                // Inform the user that the deletion was canceled
                MessageBox.Show("Delete operation canceled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
