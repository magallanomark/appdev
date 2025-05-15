using SQLite;

namespace Saha.Models
{
    public class ProgramModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Trainer { get; set; }
        public string Price { get; set; }
        public string Schedule { get; set; }
      
    }
}
