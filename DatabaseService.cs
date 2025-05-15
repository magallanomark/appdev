// DatabaseService.cs
using MySqlConnector;
using System.Threading.Tasks;

namespace Saha.Services // Using a sub-namespace for services
{
    public class DatabaseService
    {
        private readonly string _connectionString = DbConfig.ConnectionString;

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                var command = new MySqlCommand("SELECT COUNT(1) FROM Users WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);
                
                var result = await command.ExecuteScalarAsync();
                return Convert.ToInt32(result) > 0;
            }
        }

        public async Task<bool> RegisterUserAsync(string name, string email, string hashedPassword)
        {
            if (await UserExistsAsync(email))
            {
                return false; // User already exists
            }

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                var command = new MySqlCommand(
                    "INSERT INTO Users (Name, Email, PasswordHash, RegistrationDate) VALUES (@Name, @Email, @PasswordHash, @RegistrationDate)", 
                    connection);
                
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                command.Parameters.AddWithValue("@RegistrationDate", DateTime.UtcNow); // Store registration date
                
                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        // You might want to create the table if it doesn't exist (for simplicity in development)
        public async Task EnsureTableCreatedAsync()
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                var command = new MySqlCommand(@"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(255) NOT NULL,
                        Email VARCHAR(255) NOT NULL UNIQUE,
                        PasswordHash VARCHAR(255) NOT NULL,
                        RegistrationDate DATETIME DEFAULT CURRENT_TIMESTAMP
                    );", connection);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}