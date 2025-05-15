using SQLite;

namespace Saha.Models
{
    public class RequestUserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string FitnessGoal { get; set; }
        public string MedicalCondition { get; set; }
        public string Role { get; set; } = "User"; // Default role
    }
}
