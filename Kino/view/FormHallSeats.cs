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
using System.Xml.Linq;

namespace Kino.view
{
    public partial class FormHallSeats : Form
    {
        User User { get; set; }
        Form FormNavigation { get; set; }

        Movie Movie { get; set; }
        Projection Projection { get; set; }

        public Dictionary<(int, int), int> seatControlIndices = new Dictionary<(int, int), int>();

        public Dictionary<(int, int), decimal> selectedSeats = new Dictionary<(int, int), decimal> ();
        public FormHallSeats(Form formNavigation, User user, Movie movie, Projection projection)
        {
            InitializeComponent();
            Projection = projection;
            User = user;
            Movie = movie;
            FormNavigation = formNavigation;
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

            this.SuspendLayout();
            DrawSeats();
            this.ResumeLayout(false);
            buttonReserve.Enabled = false;
        }

        private void DrawSeats()
        {
            HallService hs = new HallService(labelStatus);
            Hall hall = hs.GetHallById(Projection.IdHall);
            ReservationService rs = new ReservationService(labelStatus);
            Image chairWhiteImage = (Image)Properties.Resources.ResourceManager.GetObject("chair_white");
            Image chairGrayImage = (Image)Properties.Resources.ResourceManager.GetObject("chair_gray");
            int controlIndex = 0;

            Label labelScreen = new Label()
            {
                Location = new Point(64, 30),
                Size = new Size(hall.ColumnCount * 32, 30),
                BackColor = Color.White,
                Text = "SCREEN",
                Font = new Font("Berlin Sans FB", 12),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(labelScreen);

            for (int r = 0; r < hall.RowCount; r++)
            {
                for (int c = 0; c < hall.ColumnCount; c++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Location = new Point(64 + c * 32, 90 + r * (32+15)),
                        Size = new Size(32, 32),
                        BackColor = Color.Transparent,
                        Tag = new Tuple<int, int>(r + 1, c + 1)
                    };

                    if (rs.GetReservationByProjectionRowCol(Projection.IdProjection, r + 1, c + 1) != null)
                    {
                        pictureBox.Image = chairGrayImage;
                        pictureBox.Enabled = false;
                    }
                    else
                    {
                        pictureBox.Image = chairWhiteImage;
                        labelStatus.Text ="";
                        pictureBox.Click += pictureBoxSeat_Click;
                    }

                    // Add PictureBox to the form
                    this.Controls.Add(pictureBox);

                    // Set control index for this seat
                    controlIndex = this.Controls.Count - 1; // Index of the newly added PictureBox
                    seatControlIndices[(r + 1, c + 1)] = controlIndex;
                }
            }
        }

        private void pictureBoxSeat_Click(object sender, EventArgs e)
        {
            // Load images
            Image chairWhiteImage = (Image)Properties.Resources.ResourceManager.GetObject("chair_white");
            Image chairBlueImage = (Image)Properties.Resources.ResourceManager.GetObject("chair_blue1");

            int controlIndex = -1;

            if (sender is PictureBox p)
            {
                if (p.Tag is Tuple<int, int> tag)
                {
                    int rowHall = tag.Item1; // Row number
                    int colHall = tag.Item2; // Column number
                    string newColor = string.Empty;

                    //labelStatus.Text += $"Seat at Row {rowHall}, Column {colHall} clicked.\n"; 

                    // Compare image hashes instead of direct image comparison
                    string currentImage = GetImageHash(p.Image);  // Get hash of current image
                    string whiteImageHash = GetImageHash(chairWhiteImage);  // Hash for white chair image
                    string blueImageHash = GetImageHash(chairBlueImage);  // Hash for blue chair image

                    // Check the current image hash and determine the new color
                    if (currentImage == whiteImageHash)
                    {
                        newColor = "blue";
                        //labelStatus.Text += $"Current image is chairWhiteImage, changing to blue.\n";
                    }
                    else if (currentImage == blueImageHash)
                    {
                        newColor = "white";
                        //labelStatus.Text += $"Current image is chairBlueImage, changing to white.\n"; 
                    }
                    else
                    {
                        labelStatus.Text += "Image does not match chairWhiteImage or chairBlueImage.\n"; 
                    }

                    // Retrieve the control index from the dictionary
                    if (seatControlIndices.TryGetValue((rowHall, colHall), out controlIndex))
                    {
                        //labelStatus.Text += $"Got controlIndex: {controlIndex}\n"; 

                        // Iterate through controls to find the PictureBox at the correct index
                        int j = 0;
                        foreach (Control control in this.Controls)
                        {
                            if (control is PictureBox pictureBox && j == controlIndex)
                            {
                                // Toggle the seat image based on the newColor value
                                if (newColor == "blue")
                                {
                                    pictureBox.Image = chairBlueImage; // Change to blue (selected)
                                    //labelStatus.Text += $"Seat at Row {rowHall}, Column {colHall} changed to blue.\n"; 
                                    if (!selectedSeats.ContainsKey((rowHall, colHall)))
                                    {
                                        selectedSeats[(rowHall, colHall)] = getPriceOfSeat(rowHall, colHall);
                                        buttonReserve.Enabled = true;
                                        SelectedSeatsPrintInfo();
                                    }
                                }
                                else if (newColor == "white")
                                {
                                    pictureBox.Image = chairWhiteImage; // Change to white (unselected)
                                    //labelStatus.Text += $"Seat at Row {rowHall}, Column {colHall} changed to white.\n"; 
                                    if (selectedSeats.ContainsKey((rowHall, colHall)))
                                    {
                                       selectedSeats.Remove((rowHall, colHall));
                                       if(selectedSeats.Count == 0)
                                       {
                                            buttonReserve.Enabled = false;
                                       }
                                       SelectedSeatsPrintInfo();
                                    }
                                }
                                break; // Stop the loop once the control is found and updated
                            }
                            j++; // Increment the index
                        }
                    }
                    else
                    {
                        labelStatus.Text += $"Control index for Seat at Row {rowHall}, Column {colHall} not found.\n"; // Debugging if the seat is not found in the dictionary
                    }
                }
                else
                {
                    labelStatus.Text += "Tag is missing or has an invalid type.\n"; // Debugging if Tag is invalid
                }
            }
        }

        // Helper method to get hash of an Image
        private string GetImageHash(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat); // Save image to memory stream
                byte[] imageBytes = ms.ToArray();
                var hash = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(imageBytes); // Compute hash
                return Convert.ToBase64String(hash); // Return Base64 string representation of the hash
            }
        }

        private decimal getPriceOfSeat(int row, int column)
        {
            HallService hs = new HallService(labelStatus);
            Hall hall = hs.GetHallById(Projection.IdHall);
            decimal regularPrice = (decimal)Projection.RegularPrice;

            if (row == 1)
            {
                return 0.8m * regularPrice;  
            }
            if (row == hall.RowCount)
            {
                return 1.2m * regularPrice; 
            }
            return regularPrice;
        }

        public void SelectedSeatsPrintInfo()
        {
            decimal totalPrice = 0m;
            labelSelectedSeats.Text = string.Empty;
            labelSelectedSeats.Text = "CHECKOUT \nSelected seats: ";
            foreach (var entry in selectedSeats)
            {
                var (row, col) = entry.Key; // Extract row and column from the tuple
                decimal price = entry.Value; // Extract the price associated with the seat
                totalPrice += price;

                labelSelectedSeats.Text += "\nRow: " + row + " Seat: " + col + " Price: " + price;
            }
            labelSelectedSeats.Text += "\nTOTAL PRICE: " + totalPrice;
        }

        private void buttonReserve_Click(object sender, EventArgs e)
        {
            ReceiptService receiptService = new ReceiptService(labelStatus);
            ReservationService reservationService = new ReservationService(labelStatus);

            decimal totalPrice = 0m;
            foreach (var element in selectedSeats)
            {
                decimal price = element.Value;
                totalPrice += price;
            }
            Receipt receipt = receiptService.InsertNewReceipt(User.IdUser, totalPrice);
            if(receipt != null)
            {
                foreach (var entry in selectedSeats)
                {
                    var (row, col) = entry.Key; // Extract row and column from the tuple
                    decimal price = entry.Value; // Extract the price associated with the seat
                    Reservation reservation = reservationService.InsertReservation(Projection.IdProjection, row, col, price, receipt.IdReceipt);
                }
                foreach (Control control in FormNavigation.Controls)
                {
                    if (control is Panel panel && panel.Name == "panelFormLoader")
                    {
                        panel.Controls.Clear();
                        FormReceiptDetails formReceiptDetails = new FormReceiptDetails(User, receipt);
                        formReceiptDetails.FormBorderStyle = FormBorderStyle.None;
                        panel.Controls.Add(formReceiptDetails);
                        formReceiptDetails.Show();
                    }
                }
            }
        }
    }
}
