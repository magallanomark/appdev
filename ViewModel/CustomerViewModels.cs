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


        public ICommand DeleteUserProgramCommand { get; set; }


        public CustomerViewModels()
        {
            _dbService = new SQLiteService();

            Programs = new ObservableCollection<ProgramModel>(_dbService.GetPrograms());

            UserPrograms = new ObservableCollection<UserProgram>(_dbService.GetUserProgramsByUserId(UserSession.CurrentUserId));

            DeleteUserProgramCommand = new Command<UserProgram>(OnDeleteUserProgram);


        }

        private void OnDeleteUserProgram(UserProgram userProgram)
        {
            if (userProgram == null) return;

            _dbService.DeleteUserProgram(userProgram);
            UserPrograms.Remove(userProgram);

        }


    }
}
