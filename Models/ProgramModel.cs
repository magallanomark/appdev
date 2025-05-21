using SQLite;

namespace Saha.Models
{
    public class ProgramModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Trainer_Id { get; set; }
        public string Price { get; set; }

        public int Duration { get; set; }

        [Ignore]
        public ProgramModel Program { get; set; }
        [Ignore]
        public UserModel Trainer { get; set; }

        [Ignore]
        public UserProgram TrainerProgram { get; set; }
    }
}
