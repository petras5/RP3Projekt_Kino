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
    internal class ReceiptService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Kino.Properties.Settings.CinemaDBConnectionString"].ConnectionString;
        Label statusLabel;

        public ReceiptService(Label statusLabel)
        {
            this.statusLabel = statusLabel;
        }
        public List<Receipt> GetReceipts()
        {
            List<Receipt> receipts = new List<Receipt>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Receipt ORDER BY Created DESC";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            receipts.Add(new Receipt(
                                reader.GetInt32(0),  // Id_Receipt
                                reader.GetInt32(1),  // Id_User
                                reader.GetDateTime(2) // Created
                            ));
                        }

                        if (receipts.Count == 0)
                        {
                            // MessageBox.Show("No receipts found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No receipts found in the database.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show($"Error fetching receipts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching receipts: {ex.Message}";
                    return null;
                }
            }
            return receipts;
        }

        public bool DeleteReceiptById(int idReceipt)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Receipt WHERE Id_Receipt = @IdReceipt";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@IdReceipt", idReceipt);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        statusLabel.Text = "Receipt deleted successfully.";
                        return true;
                    }
                    else
                    {
                        statusLabel.Text = "No receipt found with the given ID.";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error deleting receipt by id: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error deleting receipt by id: {ex.Message}";
                    return false;
                }
            }
        }

        public Receipt InsertNewReceipt(int idUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Prepare the insert query to add a new receipt
                    string insertQuery = "INSERT INTO Receipt (IdUser, Created) OUTPUT INSERTED.IdReceipt, INSERTED.IdUser, INSERTED.Created VALUES (@IdUser, @Created)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                    // Set the parameters
                    insertCommand.Parameters.AddWithValue("@IdUser", idUser);
                    insertCommand.Parameters.AddWithValue("@Created", DateTime.Now);

                    // Execute the query and retrieve the inserted receipt details
                    using (SqlDataReader reader = insertCommand.ExecuteReader())
                    {
                        if (reader.Read()) // Check if the receipt was inserted and data was returned
                        {
                            int idReceipt = reader.GetInt32(0);
                            int userId = reader.GetInt32(1);
                            DateTime createdDate = reader.GetDateTime(2);

                            statusLabel.Text = "Receipt added successfully.";
                            return new Receipt(idReceipt, userId, createdDate);
                        }
                        else
                        {
                            statusLabel.Text = "Error inserting receipt into the database.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    statusLabel.Text = $"Error adding receipt: {ex.Message}";
                    return null;
                }
            }
        }
    }
}
