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

        public double Progress { get; set; } // NOT Progess


        public string Status { get; set; }

        public string TransactionNumber { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        // Not mapped in SQLite - used manually
        [Ignore]
        public ProgramModel Program { get; set; }

        [Ignore]
        public UserModel Trainer { get; set; }


    }
}
