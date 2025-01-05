using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kino.model
{
    internal class MovieService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;
        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Movie";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movies.Add(new Movie(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)
                            ));
                        }
                        if (movies.Count == 0)
                        {
                            MessageBox.Show("No movies found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //statusLabel.Text = "No movies found in the database.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching movies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // statusLabel.Text = $"Error fetching movies: {ex.Message}";
                    return null;
                }
            }
            return movies;
        }

        public Movie GetMovieById(int idMovie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Movie WHERE Id_Movie = @idMovie";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idMovie", idMovie);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row exists
                        {
                            return new Movie(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)
                            );
                        }
                        else
                        {
                            MessageBox.Show("No movie with id " + idMovie + " found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //statusLabel.Text = "No movie with given id";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching movie by id: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // statusLabel.Text = $"Error fetching movie by id: {ex.Message}";
                    return null;
                }
            }
        }

        public Movie GetMovieByProjectionId(int idProjection)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT m.* FROM Movie m JOIN Projection p ON m.Id_Movie = p.Id_Movie WHERE p.Id_Projection = @idProjection";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idProjection", idProjection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Movie(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                $"No movie found for projection ID {idProjection}.",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                            // statusLabel.Text = $"No movie found for projection ID {idProjection}.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error fetching movie by projection ID: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    // statusLabel.Text = $"Error fetching movie by projection ID: {ex.Message}";
                    return null;
                }
            }
        }


        public Movie InsertMovie(string name, string description)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Movie (Name_Movie, Description) OUTPUT INSERTED.Id_Movie, INSERTED.Name_Movie, INSERTED.Description VALUES (@Name, @Description)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Name", name);
                    insertCommand.Parameters.AddWithValue("@Description", description);

                    using (SqlDataReader reader = insertCommand.ExecuteReader())
                    {
                        if (reader.Read()) // Check if the movie was inserted and data was returned
                        {
                            int idMovie = reader.GetInt32(0);
                            string movieName = reader.GetString(1);
                            string movieDescription = reader.GetString(2);

                            // statusLabel.Text = "Movie added successfully.";
                            return new Movie(idMovie, movieName, movieDescription);
                        }
                        else
                        {
                            MessageBox.Show("Error inserting movie into the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // statusLabel.Text = "Error inserting movie into the database.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding movie: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // statusLabel.Text = $"Error adding movie: {ex.Message}";
                    return null;
                }
            }
        }

        public bool DeleteMovieIfNeeded(int idMovie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT * FROM Projection WHERE Id_Movie = @idMovie";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@idMovie", idMovie);

                    int numberOfRows = checkCommand.ExecuteNonQuery();

                    if (numberOfRows == 0) // If no rows exist, delete the movie from 'Movie' table
                    {
                        string deleteQuery = "DELETE FROM Movie WHERE Id_Movie = @idMovie";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@idMovie", idMovie);

                        int affectedRows = deleteCommand.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            // labelStatus.Text = "Movie deleted successfully.";
                            return true;
                        }
                    }
                    // labelStatus.Text = "Movie could not be deleted.";
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error deleting movie: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    // labelStatus.Text = $"Error deleting movie: {ex.Message}";
                    return false;
                }
            }
        }

    }
}

