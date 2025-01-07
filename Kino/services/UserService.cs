using Kino.model;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.services
{
    internal class UserService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Kino.Properties.Settings.CinemaDBConnectionString"].ConnectionString;
        Label statusLabel;

        public UserService(Label statusLabel)
        {
            this.statusLabel = statusLabel;
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM [User]";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetByte(5)
                            ));
                        }
                        if (users.Count == 0)
                        {
                            //MessageBox.Show("No users found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No users found in the database.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching users: {ex.Message}";
                    return null;
                }
            }
            return users;
        }

        public User GetUserById(int idUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM [User] WHERE Id_User = @idUser";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idUser", idUser);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row exists
                        {
                            return new User(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetByte(5)
                            );
                        }
                        else
                        {
                            //MessageBox.Show("No user with id " + idUser + " found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "No user with given id " + idUser;
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching user by id: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching user by id: {ex.Message}";
                    return null;
                }
            }
        }

        public User GetExistingUserByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM [User] WHERE Username = @username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row exists
                        {
                            //MessageBox.Show("User with username " + username + "already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusLabel.Text = "User with username " + username + "already exists.";
                            return new User(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetByte(5)
                            );
                        }
                        else
                        {
                            statusLabel.Text = "No user with given username " + username;
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error fetching user by username: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error fetching user by username: {ex.Message}";
                    return null;
                }
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string hashedInput = HashPassword(inputPassword);
            return hashedInput == storedHash;
        }

        public User InsertUser(string username, string firstName, string lastName, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Hash the password
                    string passwordHash = HashPassword(password);

                    // Define the query with OUTPUT to return the inserted user's details
                    string insertQuery = @"INSERT INTO [User] (Username, Name, Surname, Password_Hash, Role) 
                                   OUTPUT INSERTED.Id_User, INSERTED.Username, INSERTED.Name, INSERTED.Surname, INSERTED.Password_Hash, INSERTED.Role 
                                   VALUES (@Username, @Name, @Surname, @PasswordHash, @Role)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Username", username);
                    insertCommand.Parameters.AddWithValue("@Name", firstName);
                    insertCommand.Parameters.AddWithValue("@Surname", lastName);
                    insertCommand.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    insertCommand.Parameters.AddWithValue("@Role", 1); // Default role value

                    using (SqlDataReader reader = insertCommand.ExecuteReader())
                    {
                        if (reader.Read()) // Check if the user was inserted and data was returned
                        {
                            int idUser = reader.GetInt32(0);
                            string userUsername = reader.GetString(1);
                            string userName = reader.GetString(2);
                            string userSurname = reader.GetString(3);
                            string userPasswordHash = reader.GetString(4);
                            int userRole = reader.GetByte(5); // Role is TINYINT, map to a byte

                            statusLabel.Text = "User added successfully.";
                            return new User(idUser, userUsername, userName, userSurname, userPasswordHash, userRole);
                        }
                        else
                        {
                            //MessageBox.Show("Error inserting user into the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            statusLabel.Text = "Error inserting user into the database.";
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error adding user: {ex.Message}";
                    return null;
                }
            }
        }


        public User VerifyUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM [User] WHERE Username = @username";

                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a user was found
                        {
                            int idUser = reader.GetInt32(0);
                            string dbUsername = reader.GetString(1);
                            string name = reader.GetString(2);
                            string surname = reader.GetString(3);
                            string passwordHash = reader.GetString(4);
                            int role = reader.GetByte(5);

                            // Verify the password
                            if (VerifyPassword(password, passwordHash))
                            {
                                // Return the user if the password is correct
                                return new User(idUser, dbUsername, name, surname, passwordHash, role);
                            }
                        }
                    }

                    //MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    statusLabel.Text = "Invalid username or password.";
                    return null;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error verifying user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error verifying user: {ex.Message}";
                    return null;
                }
            }
        }

        public void UpdateUserRole(int idUser, int role)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Define the query to update the user's role
                    string updateQuery = "UPDATE [User] SET Role = @Role WHERE Id_User = @IdUser";

                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@Role", role);
                    updateCommand.Parameters.AddWithValue("@IdUser", idUser);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("User role updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        statusLabel.Text = "User role updated successfully.";
                    }
                    else
                    {
                        //MessageBox.Show("No user found with the given ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        statusLabel.Text = "No user found with the given ID.";
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error updating user role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Error updating user role: {ex.Message}";
                }
            }
        }


    }
}
