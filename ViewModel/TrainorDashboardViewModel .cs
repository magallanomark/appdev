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
        public ObservableCollection<UserModel> Trainers { get; set; }

        public TrainorDashboardViewModel()
        {

            db = new SQLiteService();

            int userId = UserSession.CurrentUserId;

            AssignedPrograms = new ObservableCollection<ProgramModel>(db.GetProgramsByUserId(userId));
        }

        public void LoadPrograms()
        {
            // Load programs from the database or any other source

        }


    }
}
