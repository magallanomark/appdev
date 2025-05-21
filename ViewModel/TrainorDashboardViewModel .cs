using System.Collections.ObjectModel;
using System.Linq;
using Saha.Models;
using Saha.Services;

namespace Saha.ViewModel
{
    public class TrainorDashboardViewModel
    {


        SQLiteService db;
        public ObservableCollection<ProgramModel> AssignedPrograms { get; set; }

        public ObservableCollection<ProgramModel> UserPrograms { get; set; }
        public ObservableCollection<UserModel> Trainers { get; set; }
        public ObservableCollection<DisplayProgramViewModel> MyPrograms { get; set; }


        public TrainorDashboardViewModel()
        {

            db = new SQLiteService();

            int userId = UserSession.CurrentUserId;

            AssignedPrograms = new ObservableCollection<ProgramModel>(db.GetProgramsByUserId(userId));
            //  var trainorPrograms = db.GetUserProgramsByTrainorId(userId);

            MyPrograms = new ObservableCollection<DisplayProgramViewModel>();

            var trainorPrograms = db.GetUserProgramsByTrainorId(userId);

            foreach (var item in trainorPrograms)
            {
                foreach (var userProgram in item.UserPrograms)
                {
                    DateTime start = DateTime.Parse(userProgram.StartDate);
                    DateTime end = DateTime.Parse(userProgram.EndDate);
                    DateTime today = DateTime.Today;

                    double totalDays = (end - start).TotalDays;
                    double elapsedDays = (today - start).TotalDays;

                    // Clamp the value between 0.0 and 1.0
                    double progress = Math.Max(0, Math.Min(1, elapsedDays / totalDays));

                    MyPrograms.Add(new DisplayProgramViewModel
                    {
                        Name = item.Program.Name,
                        Description = item.Program.Description,
                        StartDate = start.ToString("MMMM dd, yyyy"),
                        EndDate = end.ToString("MMMM dd, yyyy"),
                        Progess = progress
                    });
                }
            }
        }

        public void LoadPrograms()
        {
            // Load programs from the database or any other source

        }
        public class DisplayProgramViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public double Progess { get; set; } // As a decimal from 0.0 to 1.0
        }



    }
}
