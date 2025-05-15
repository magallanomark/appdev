using System.Collections.ObjectModel;
using System.Windows.Input;
using Saha.Models;
using Saha.Services;

namespace Saha.ViewModel
{
    public class RequestUsersViewModel
    {
        private SQLiteService _dbService;

        public ObservableCollection<RequestUserModel> RequestUsers { get; set; }

        public ICommand AcceptCommand { get; }
        public ICommand DeleteCommand { get; }

        public RequestUsersViewModel()
        {
            _dbService = new SQLiteService();
            
            RequestUsers = new ObservableCollection<RequestUserModel>(_dbService.GetRequestUsers());

            AcceptCommand = new Command<RequestUserModel>(OnAcceptUser);
            DeleteCommand = new Command<RequestUserModel>(OnDeleteUser);
        }

        private void OnAcceptUser(RequestUserModel requestUser)
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
                MedicalCondition = requestUser.MedicalCondition,
                Role = requestUser.Role
            };

            _dbService.AddUser(acceptedUser);
            _dbService.DeleteRequestUser(requestUser);
            RequestUsers.Remove(requestUser);
        }

        private void OnDeleteUser(RequestUserModel requestUser)
        {
            if (requestUser == null) return;

            _dbService.DeleteRequestUser(requestUser);
            RequestUsers.Remove(requestUser);
        }
    }
}
