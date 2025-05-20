using SQLite;

namespace Saha.Models
{
    public class UserProgram
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProgramId { get; set; }
        // public string Status { get; set; }

        public int Progess { get; set; }


        public string StartDate { get; set; }
    }
}
