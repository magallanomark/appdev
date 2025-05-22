using System.Collections.ObjectModel;
using System.Windows.Input;
using Saha.Models;
using Saha.Services;

namespace Saha.ViewModel
{
    public class CustomerViewModels
    {
        private SQLiteService _dbService;


        public ObservableCollection<ProgramModel> Programs { get; set; }

        public ObservableCollection<UserProgram> UserPrograms { get; set; }

        public ObservableCollection<UserProgram> MyPrograms { get; set; }


        public ICommand DeleteUserProgramCommand { get; set; }


        public CustomerViewModels()
        {
            _dbService = new SQLiteService();

            Programs = new ObservableCollection<ProgramModel>(_dbService.GetAvailableProgramsByCustomer(UserSession.CurrentUserId));

            UserPrograms = new ObservableCollection<UserProgram>(_dbService.GetUserProgramsByUserId(UserSession.CurrentUserId));

            DeleteUserProgramCommand = new Command<UserProgram>(OnDeleteUserProgram);

            if (UserSession.CurrentUserId == 0) return; // or your default invalid ID check

            foreach (var userProgram in _dbService.GetUserProgramsByUserId(UserSession.CurrentUserId))
            {
                var records = _dbService.GetAttendanceRecordsByUserProgramId(userProgram.Id);
                int total = records.Count;
                int presentCount = records.Count(r => r.IsPresent);
                double Valprogress = total == 0 ? 0 : (double)presentCount / total;

                //MyPrograms.Add(new UserProgram
                //{
                //    UserId = userProgram.UserId,
                //    ProgramId = userProgram.ProgramId,
                //    Progress = Valprogress,
                //    Status = userProgram.Status,
                //    TransactionNumber = userProgram.TransactionNumber,
                //    StartDate = userProgram.StartDate,
                //    EndDate = userProgram.EndDate
                //});
            }




        }

        private void OnDeleteUserProgram(UserProgram userProgram)
        {
            if (userProgram == null) return;

            // Delete attendance first
            _dbService.DeleteAttendanceByUserProgramId(userProgram.Id);
            _dbService.DeleteUserProgram(userProgram);
            UserPrograms.Remove(userProgram);

        }


    }
}
