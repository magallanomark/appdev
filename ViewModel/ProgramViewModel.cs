using System.Collections.ObjectModel;
using System.Windows.Input;
using Saha.Models;
using Saha.Services;
using Saha.Modals;
using Saha.ViewModel;
using System.Diagnostics;

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

        public ICommand DeleteUserProgramCommand { get; }

        public ObservableCollection<UserProgram> userPrograms { get; set; }
        public ObservableCollection<UserProgram> userProgramsReviewed { get; set; }

        public ICommand AcceptProgramCommand { get; set; }
        public ICommand RejectProgramCommand { get; set; }


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

            DeleteUserProgramCommand = new Command<UserProgram>(OnDeleteUserProgram);

            userPrograms = new ObservableCollection<UserProgram>(_dbService.GetUserPrograms());

            userProgramsReviewed = new ObservableCollection<UserProgram>(_dbService.GetUserAllPrograms());

            AcceptProgramCommand = new Command<UserProgram>(OnAccept);
            RejectProgramCommand = new Command<UserProgram>(OnReject);

        }

        private async void OnAccept(UserProgram userProgram)
        {
            if (userProgram == null)
            {
                await Shell.Current.DisplayAlert("Error", "User program is null", "OK");
                return;
            }

            Debug.WriteLine($"UserProgram ID: {userProgram.Id}");

            // Update the status of the program to accepted
            userProgram.Status = "Accepted";
            _dbService.UpdateUserProgram(userProgram);
            userPrograms.Remove(userProgram);


        }
        private void OnReject(UserProgram userProgram)
        {
            if (userProgram == null) return;

            // Update the status of the program to rejected
            userProgram.Status = "Rejected";
            _dbService.UpdateUserProgram(userProgram);
            userPrograms.Remove(userProgram);
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

        private void OnDeleteUserProgram(UserProgram userProgram)
        {
            if (userProgram == null) return;

            Debug.WriteLine($"UserProgram ID: {userProgram.Id} - Here");

            _dbService.DeleteUserProgram(userProgram);
            userProgramsReviewed.Remove(userProgram);
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
