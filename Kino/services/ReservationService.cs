using Kino.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.services
{
    internal class ReservationService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Kino.Properties.Settings.CinemaDBConnectionString"].ConnectionString;
        Label statusLabel;

        public ReservationService(Label statusLabel)
        {
            this.statusLabel = statusLabel;
        }
        public List<Reservation> GetReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Reservation";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservations.Add(new Reservation(
                                reader.GetInt32(0),  // Id_Reservation
                                reader.GetInt32(1),  // Id_Projection
                                reader.GetInt32(2),  // Row
                                reader.GetInt32(3),  // Column
                                reader.GetDecimal(4), // Price
                                reader.GetInt32(5) // Id_Receipt
                            ));
                        }

                        if (reservations.Count == 0)
                        {
                            // MessageBox.Show("No reservations found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No reservations found in the database.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show($"Error fetching reservations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching reservations: {ex.Message}";
                    return null;
                }
            }
            return reservations;
        }

        public Reservation GetReservationById(int idReservation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Reservation WHERE Id_Reservation = @idReservation";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idReservation", idReservation);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row exists
                        {
                            return new Reservation(
                                reader.GetInt32(0),  // Id_Reservation
                                reader.GetInt32(1),  // Id_Projection
                                reader.GetInt32(2),  // Row
                                reader.GetInt32(3),  // Column
                                reader.GetDecimal(4), // Price
                                reader.GetInt32(5) // Id_Receipt
                            );
                        }
                        else
                        {
                            //MessageBox.Show("No reservation with id " + idReservation + " found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No reservation with given id" + idReservation;
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching reservation by id: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching reservation by id: {ex.Message}";
                    return null;
                }
            }
        }


        public List<Reservation> GetReservationsByReceiptId(int idReceipt)
        {
            List<Reservation> reservations = new List<Reservation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Reservation WHERE Id_Receipt = @idReceipt";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idReceipt", idReceipt);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservations.Add(new Reservation(
                                reader.GetInt32(0),  // Id_Reservation
                                reader.GetInt32(1),  // Id_Projection
                                reader.GetInt32(2),  // Row
                                reader.GetInt32(3),  // Column
                                reader.GetDecimal(4), // Price
                                reader.GetInt32(5) // Id_Receipt
                            ));
                        }

                        if (reservations.Count == 0)
                        {
                            //MessageBox.Show("No reservations for user with id " + idReceipt + " found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No reservations for user with id " + idReceipt + " found.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching reservation by receipt id: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching reservation by receipt id: {ex.Message}";
                    return null;
                }
            }
            return reservations;
        }

        public List<Reservation> GetReservationsByProjectionId(int idProjection)
        {
            List<Reservation> reservations = new List<Reservation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Reservation WHERE Id_Projection = @idProjection";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idProjection", idProjection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservations.Add(new Reservation(
                                reader.GetInt32(0),  // Id_Reservation
                                reader.GetInt32(1),  // Id_Projection
                                reader.GetInt32(2),  // Row
                                reader.GetInt32(3),  // Column
                                reader.GetDecimal(4), // Price
                                reader.GetInt32(5) // Id_Receipt
                            ));
                        }

                        if (reservations.Count == 0)
                        {
                            //MessageBox.Show("No reservations for projection with id " + idProjection + " found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No reservations for projection with id " + idProjection + " found.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching reservation by projection id: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching reservation by projection id: {ex.Message}";
                    return null;
                }
            }
            return reservations;
        }

        public int GetNumberOfReservationsByProjectionId(int idProjection)
        {
            // Get all reservations for the given projection
            var reservations = GetReservationsByProjectionId(idProjection);

            // If no reservations are found, return 0
            if (reservations == null)
            {
                return 0;
            }

            // Return the count of reservations
            return reservations.Count;
        }

        public Reservation GetReservationByProjectionRowCol(int idProjection, int row, int col)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT * FROM Reservation 
                             WHERE Id_Projection = @IdProjection 
                             AND Row = @Row 
                             AND Column = @Col";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdProjection", idProjection);
                    command.Parameters.AddWithValue("@Row", row);
                    command.Parameters.AddWithValue("@Col", col);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row is returned
                        {
                            return new Reservation(
                                reader.GetInt32(0),  // Id_Reservation
                                reader.GetInt32(1),  // Id_Projection
                                reader.GetInt32(2),  // Row
                                reader.GetInt32(3),  // Column
                                reader.GetDecimal(4), // Price
                                reader.GetInt32(5) // Id_Receipt
                            );
                        }
                        else
                        {
                            //MessageBox.Show("No reservation found for the given projection, row, and column.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No reservation found for the given projection, row, and column.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching reservation: {ex.Message}";
                    return null;
                }
            }
        }

        public Reservation InsertReservation(int idProjection, int row, int column, decimal price, int idReceipt)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to insert a new reservation and return the inserted data
                    string insertQuery = @"INSERT INTO Reservation (Id_Projection, Row, Column, Price, Id_Receipt) 
                        VALUES (@IdProjection, @Row, @Column, @Price, @IdReceipt)
                        OUTPUT INSERTED.Id_Reservation, INSERTED.Id_Projection, INSERTED.Row, INSERTED.Column, INSERTED.Price, INSERTED.Id_Receipt";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                    insertCommand.Parameters.AddWithValue("@IdReceipt", idReceipt);
                    insertCommand.Parameters.AddWithValue("@IdProjection", idProjection);
                    insertCommand.Parameters.AddWithValue("@Row", row);
                    insertCommand.Parameters.AddWithValue("@Column", column);
                    insertCommand.Parameters.AddWithValue("@Price", price);

                    using (SqlDataReader reader = insertCommand.ExecuteReader())
                    {
                        if (reader.Read()) // Check if the reservation was inserted and data was returned
                        {
                            statusLabel.Text = "Reservation inserted successfully.";

                            return new Reservation(
                                reader.GetInt32(0),  // Id_Reservation
                                reader.GetInt32(1),  // Id_Projection
                                reader.GetInt32(2),  // Row
                                reader.GetInt32(3),  // Column
                                reader.GetDecimal(4), // Price
                                reader.GetInt32(5) // Id_Receipt
                            );
                        }
                        else
                        {
                            //MessageBox.Show("Error inserting reservation into the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            statusLabel.Text = "Error inserting reservation into the database.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error adding reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error adding reservation: {ex.Message}";
                    return null;
                }
            }
        }

        public bool DeleteReservationById(int idReservation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Reservation WHERE Id_Reservation = @IdReservation";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@IdReservation", idReservation);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        statusLabel.Text = "Reservation deleted successfully.";
                        return true;
                    }
                    else
                    {
                        statusLabel.Text = "No reservation found with the given ID.";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error deleting reservation by id: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error deleting reservation by id: {ex.Message}";
                    return false;
                }
            }
        }

        public bool DeleteReservationByProjectionRowCol(int idProjection, int row, int col)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string deleteQuery = @"DELETE FROM Reservation 
                                   WHERE Id_Projection = @IdProjection 
                                   AND Row = @Row 
                                   AND Column = @Col";

                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);

                    deleteCommand.Parameters.AddWithValue("@IdProjection", idProjection);
                    deleteCommand.Parameters.AddWithValue("@Row", row);
                    deleteCommand.Parameters.AddWithValue("@Col", col);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        statusLabel.Text = "Reservation deleted successfully.";
                        return true;
                    }
                    else
                    {
                        statusLabel.Text = "No reservation found with the given row and column.";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error deleting reservation by row and column: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error deleting reservation by row and column: {ex.Message}";
                    return false;
                }
            }
        }

    }
}
