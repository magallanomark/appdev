using System.Collections.ObjectModel;
using System.Windows.Input;
using Saha.Services;

namespace Saha.Models  // or your correct namespace
{
    public class ProgramWithTrainer
    {
        public ProgramModel Program { get; set; }
        public UserModel Trainer { get; set; }

        public string TrainerName => Trainer?.FullName ?? "Unknown";
    }
}

