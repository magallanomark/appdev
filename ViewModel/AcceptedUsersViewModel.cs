using System.Collections.ObjectModel;
using System.Windows.Input;
using Saha.Models;
using Saha.Services;
using Saha.Modals;

namespace Saha.ViewModel
{
    public class AcceptUsersViewModel
    {
        private SQLiteService _dbService;

        public ObservableCollection<UserModel> AcceptedUsers { get; set; }
        public ICommand EditCommand { get; }

        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public AcceptUsersViewModel()
        {
            _dbService = new SQLiteService();
            
            AcceptedUsers = new ObservableCollection<UserModel>(_dbService.GetUsers());

            EditCommand = new Command<UserModel>(OnEditUser);

            UpdateCommand = new Command<UserModel>(OnUpdateUser);
            DeleteCommand = new Command<UserModel>(OnDeleteUser);
        }
        
        private async void OnEditUser(UserModel user)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UpdateUserPage(user, this));
        }

        private void OnUpdateUser(UserModel requestUser)
        {
            if (requestUser == null) return;

            // Move to main users table
            var acceptedUser = new UserModel
            {
                FullName = requestUser.FullName,
                Email = requestUser.Email,
                Password = requestUser.Password,
                PhoneNumber = requestUser.PhoneNumber,
                Age = requestUser.Age,
                Gender = requestUser.Gender,
                FitnessGoal = requestUser.FitnessGoal,
                MedicalCondition = requestUser.MedicalCondition
            };

            


        }

        private void OnDeleteUser(UserModel requestUser)
        {
            if (requestUser == null) return;

            _dbService.DeleteUser(requestUser);
            AcceptedUsers.Remove(requestUser);

        }
    }
}
