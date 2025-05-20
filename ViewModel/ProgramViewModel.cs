using System.Collections.ObjectModel;
using System.Windows.Input;
using Saha.Models;
using Saha.Services;
using Saha.Modals;
using Saha.ViewModel;

namespace Saha.ViewModel
{
    public class ProgramViewModel
    {
        private SQLiteService _dbService;

        // public ObservableCollection<ProgramModel> ProgramModels { get; set; }

        public ObservableCollection<UserModel> TrainorsModels { get; set; }

        public ObservableCollection<ProgramWithTrainer> ProgramWithTrainerModels { get; set; }

        public ObservableCollection<ProgramWithTrainerViewModel> ProgramModels { get; set; }

        public ICommand EditCommand { get; }

        public ICommand SaveProgram { get; }
        public ICommand DeleteCommand { get; }

        public ICommand DeleteProgramCommand { get; }

        public ProgramViewModel()
        {
            _dbService = new SQLiteService();

            //ProgramModels = new ObservableCollection<ProgramModel>(_dbService.GetPrograms());

            EditCommand = new Command<ProgramModel>(OnEditUser);
            SaveProgram = new Command<ProgramModel>(SaveProgramCommand);
            DeleteCommand = new Command<ProgramModel>(OnDeleteUser);

            TrainorsModels = new ObservableCollection<UserModel>(_dbService.GetTrainors());

            ProgramWithTrainerModels = new ObservableCollection<ProgramWithTrainer>(_dbService.GetProgramsWithTrainer());

            LoadPrograms();

            DeleteProgramCommand = new Command<ProgramWithTrainerViewModel>(DeleteProgram);

        }

        private void LoadPrograms()
        {
            var programs = _dbService.GetPrograms();
            var users = _dbService.GetUsers();

            var joined = programs.Select(p =>
            {
                var trainer = users.FirstOrDefault(u => u.Id == p.Trainer_Id);
                return new ProgramWithTrainerViewModel
                {
                    Program = p,
                    Trainer = trainer
                };
            });

            ProgramModels = new ObservableCollection<ProgramWithTrainerViewModel>(joined);
        }

        private void DeleteProgram(ProgramWithTrainerViewModel programVM)
        {
            if (programVM == null)
                return;

            // Delete from DB
            _dbService.DeleteProgram(programVM.Program);

            // Remove from observable collection (updates UI)
            ProgramModels.Remove(programVM);
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
