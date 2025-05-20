using Saha.Models;

namespace Saha.ViewModel
{
    public class ProgramWithTrainerViewModel
    {
        public int Id => Program.Id;
        public string Name => Program.Name;
        public string Description => Program.Description;
        public string Schedule => Program.Schedule;
        public string Price => Program.Price;
        public string TrainerName => Trainer?.FullName ?? "Unknown";

        public ProgramModel Program { get; set; }
        public UserModel Trainer { get; set; }
    }
}
