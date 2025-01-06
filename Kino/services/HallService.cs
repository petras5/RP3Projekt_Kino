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
    internal class HallService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;

        Label statusLabel;
        public HallService(Label statusLabel)
        {
            this.statusLabel = statusLabel;
        }
        public List<Hall> GetHalls()
        {
            List<Hall> halls = new List<Hall>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Hall";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            halls.Add(new Hall(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2)
                            ));
                        }
                        if (halls.Count == 0)
                        {
                            //MessageBox.Show("No halls found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No halls found in the database.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching halls: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching halls: {ex.Message}";
                    return null;
                }
            }
            return halls;
        }

        public Hall GetHallById(int idHall)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Hall WHERE Id_Hall = @idHall";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idHall", idHall);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row exists
                        {
                            return new Hall(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2)
                            );
                        }
                        else
                        {
                            //MessageBox.Show("No hall with id " + idHall + " found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No hall with given id" + idHall;
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching hall by id: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching hall by id: {ex.Message}";
                    return null;
                }
            }
        }
    }
}
