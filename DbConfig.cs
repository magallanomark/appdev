// DbConfig.cs
namespace Saha
{
    public static class DbConfig
    {
        // IMPORTANT: Replace with your actual MySQL connection details
        // For local development, this might be:
        // Server=localhost; Port=3306; Database=your_gym_app_db; Uid=your_user; Pwd=your_password;
        // Ensure your_gym_app_db exists and your_user has permissions.
        public const string ConnectionString = "Server=YOUR_MYSQL_SERVER;Port=3306;Database=gym_app_db;Uid=root;Pwd=''";
    }
}