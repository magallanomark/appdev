using System.Collections.ObjectModel;
using System.Windows.Input;
using Saha.Models;
using Saha.Services;
using Saha.Modals;

namespace Saha.ViewModel
{
    public class ProgramViewModel
    {
        private SQLiteService _dbService;

        public ObservableCollection<ProgramModel> ProgramModels { get; set; }
        public ICommand EditCommand { get; }

        public ICommand SaveProgram { get; }
        public ICommand DeleteCommand { get; }

        public ProgramViewModel()
        {
            _dbService = new SQLiteService();
            
            ProgramModels = new ObservableCollection<ProgramModel>(_dbService.GetPrograms());

            EditCommand = new Command<ProgramModel>(OnEditUser);
            SaveProgram = new Command<ProgramModel>(SaveProgramCommand);
            DeleteCommand = new Command<ProgramModel>(OnDeleteUser);
        }
        
        private async void OnEditUser(ProgramModel user)
        {
          //  await Application.Current.MainPage.Navigation.PushAsync(new UpdateUserPage(user, this));
        }

        private void OnUpdateProgram(ProgramModel requestUser)
        {
            if (requestUser == null) return;

            


        }
        private void SaveProgramCommand(ProgramModel requestUser)
        {
            if (requestUser == null) return;

            


        }

        private void OnDeleteUser(ProgramModel requestUser)
        {
            if (requestUser == null) return;


        }
    }
}
