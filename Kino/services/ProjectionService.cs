using Kino.model;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.services
{
    internal class ProjectionService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Kino.Properties.Settings.CinemaDBConnectionString"].ConnectionString;
        Label statusLabel;

        public ProjectionService(Label statusLabel)
        {
            this.statusLabel = statusLabel;
        }
        public List<Projection> GetProjections()
        {
            List<Projection> projections = new List<Projection>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Projection ORDER BY Date ASC, Time ASC";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projections.Add(new Projection(
                                reader.GetInt32(0),
                                reader.GetInt32(1), 
                                reader.GetInt32(2), 
                                reader.GetDateTime(3), 
                                reader.GetTimeSpan(4), 
                                reader.GetInt32(5)  
                            ));
                        }
                        if (projections.Count == 0)
                        {
                            //MessageBox.Show("No projections found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No projections found in the database.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching projections: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching projections: {ex.Message}";
                    return null;
                }
            }
            return projections;
        }

        public Projection GetProjectionById(int idProjection)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Projection WHERE Id_Projection = @idProjection ORDER BY Date ASC, Time ASC";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idProjection", idProjection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row exists
                        {
                            return new Projection(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetDateTime(3),
                                reader.GetTimeSpan(4),
                                reader.GetInt32(5)
                            );
                        }
                        else
                        {
                            //MessageBox.Show("No projection with id " + idProjection + " found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //statusLabel.Text = "No projection with given id" + idProjection;
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching projection by id: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching projection by id: {ex.Message}";
                    return null;
                }
            }
        }

        public List<Projection> GetProjectionsByMovieId(int idMovie)
        {
            List<Projection> projections = new List<Projection>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT * FROM Projection WHERE Id_Movie = @idMovie ORDER BY Date ASC, Time ASC";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idMovie", idMovie);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projections.Add(new Projection(
                                reader.GetInt32(0),  
                                reader.GetInt32(1),  
                                reader.GetInt32(2),  
                                reader.GetDateTime(3),  
                                reader.GetTimeSpan(4),  
                                reader.GetInt32(5)   
                            ));
                        }
                    }

                    if (projections.Count == 0)
                    {
                        /*
                        MessageBox.Show(
                            $"No projections found for movie ID {idMovie}.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        */
                        //statusLabel.Text = $"No projections found for movie ID {idMovie}.";
                        return null;
                    }

                    return projections;
                }
                catch (Exception ex)
                {
                    /*
                    MessageBox.Show(
                        $"Error fetching projections by movie ID: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    */
                    statusLabel.Text = $"Error fetching projections by movie ID: {ex.Message}";
                    return null;
                }
            }
        }

        public Projection InsertNewProjection(int idHall, int idMovie, DateTime date, TimeSpan time, int regularPrice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to insert a new projection and return the inserted data
                    string insertQuery = @"INSERT INTO Projection (Id_Hall, Id_Movie, Date, Time, Regular_Price) 
                        OUTPUT INSERTED.Id_Projection, INSERTED.Id_Hall, INSERTED.Id_Movie, INSERTED.Date, INSERTED.Time, INSERTED.Regular_Price
                        VALUES (@IdHall, @IdMovie, @Date, @Time, @RegularPrice)";
                       

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                    insertCommand.Parameters.AddWithValue("@IdHall", idHall);
                    insertCommand.Parameters.AddWithValue("@IdMovie", idMovie);
                    insertCommand.Parameters.AddWithValue("@Date", date);
                    insertCommand.Parameters.AddWithValue("@Time", time);
                    insertCommand.Parameters.AddWithValue("@RegularPrice", regularPrice);

                    using (SqlDataReader reader = insertCommand.ExecuteReader())
                    {
                        if (reader.Read()) // Check if the projection was inserted and data was returned
                        {
                            int idProjection = reader.GetInt32(0);
                            int hallId = reader.GetInt32(1);
                            int movieId = reader.GetInt32(2);
                            DateTime projectionDate = reader.GetDateTime(3);
                            TimeSpan projectionTime = reader.GetTimeSpan(4);
                            int price = reader.GetInt32(5);

                            statusLabel.Text = "Projection inserted successfully.";

                            // Return the newly inserted Projection object
                            return new Projection(idProjection, hallId, movieId, projectionDate, projectionTime, price);
                        }
                        else
                        {
                            //MessageBox.Show("Error inserting projection into the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            statusLabel.Text = "Error inserting projection into the database.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error adding projection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error adding projection: {ex.Message}";
                    return null;
                }
            }
        }

        public Projection GetProjectionByDateTimeHall(DateTime date, TimeSpan time, int hall)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT * FROM Projection 
                             WHERE Date = @Date 
                             AND Time = @Time 
                             AND Id_Hall = @Hall";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Use appropriate SqlDbType to avoid potential type issues.
                    command.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                    command.Parameters.Add("@Time", SqlDbType.Time).Value = time;
                    command.Parameters.Add("@Hall", SqlDbType.Int).Value = hall;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row exists
                        {
                            return new Projection(
                                reader.GetInt32(0),  // Id_Projection
                                reader.GetInt32(1),  // Id_Hall
                                reader.GetInt32(2),  // Id_Movie
                                reader.GetDateTime(3),  // Date
                                reader.GetTimeSpan(4),  // Time
                                reader.GetInt32(5)   // Regular_Price
                            );
                        }
                        else
                        {
                            // No rows found
                            statusLabel.Text = "No projection found with the given criteria.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception message to the status label
                    statusLabel.Text = $"Error fetching projection: {ex.Message}";
                    return null;
                }
            }
        }


        public bool DeleteProjectionById(int idProjection)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Projection WHERE Id_Projection = @IdProjection";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@IdProjection", idProjection);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        statusLabel.Text = "Projection deleted successfully.";
                        return true;
                    }
                    else
                    {
                        statusLabel.Text = "No projection found with the given ID.";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error deleting projection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error deleting projection: {ex.Message}";
                    return false;
                }
            }
        }

        /*

        public bool CheckCollision(int idHall, DateTime date, TimeSpan time)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM Projection WHERE Time < DATEADD(HOUR, 3, @Time) AND @Time < DATEADD(HOUR, 3, Time) 
                    AND Id_Hall = @IdHall AND Date = @Date";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@IdHall", idHall);
                    command.Parameters.AddWithValue("@Date", date);

                    int affectedRows = (int)command.ExecuteNonQuery(); 

                    if (affectedRows > 0)
                    {
                        //MessageBox.Show($"There are {affectedRows} projections in collision for the selected time.", "Collision Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        statusLabel.Text = $"Collision detected with {affectedRows} projections.";
                        return false; // Collision found.
                    }

                    return true; // No collision.
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error checking for collision: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error checking for collision: {ex.Message}";
                    return false; // Error occurred.
                }
            }
        }

        */
        public bool CheckCollision(int idHall, DateTime date, TimeSpan time)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    /*
                        string query = @"SELECT COUNT(*) 
FROM Projection
WHERE Time BETWEEN DATEADD(HOUR, -3, @Time) AND DATEADD(HOUR, 3, @Time) 
AND Id_Hall = @IdHall
AND Date = @Date";*/
                    TimeSpan lowerBound = time - TimeSpan.FromHours(3);
                    TimeSpan upperBound = time + TimeSpan.FromHours(3);

                    /*string query = @"SELECT COUNT(*) FROM Projection 
                             WHERE [Time] < DATEADD(HOUR, 3, CAST(@Time AS DATETIME)) 
                             AND @Time < DATEADD(HOUR, 3,  CAST([Time] AS DATETIME)) 
                             AND Id_Hall = @IdHall 
                             AND Date = @Date";*/

                    string query;
                    bool crossesMidnight = upperBound > TimeSpan.FromHours(24);
                    DateTime dateAfter = date.AddDays(1);
                    if (crossesMidnight)
                    {
                        upperBound -= TimeSpan.FromHours(24); // Wrap around midnight
                        query = @"SELECT COUNT(*) 
                             FROM Projection 
                             WHERE (Date = @Date AND Time > @LowerBound)
                             OR (Date = @DateAfter AND Time < @UpperBound)";

                    } 
                    else
                    {
                        query = @"SELECT COUNT(*) 
                             FROM Projection 
                             WHERE 
                                 Time BETWEEN @LowerBound AND @UpperBound AND
                                 Id_Hall = @IdHall AND 
                                 Date = @Date";
                    }



                    SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@LowerBound", lowerBound);
                    command.Parameters.AddWithValue("@UpperBound", upperBound);
                    command.Parameters.AddWithValue("@IdHall", idHall);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@DateAfter", dateAfter);

                    // Use ExecuteScalar to get the count result
                    int affectedRows = (int)command.ExecuteScalar();

                    if (affectedRows > 0)
                    {
                        // MessageBox.Show($"There are {affectedRows} projections in collision for the selected time.", "Collision Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        statusLabel.Text = $"Collision detected with {affectedRows} projections.";
                        return false; // Collision found.
                    }

                    return true; // No collision.
                }
                catch (Exception ex)
                {
                    // MessageBox.Show($"Error checking for collision: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error checking for collision: {ex.Message}";
                    return false; // Error occurred.
                }
            }
        }

    }
}
