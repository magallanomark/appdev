using System;
using System.Collections.Generic;
using Saha.Admin;
using Saha.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Saha.ViewModel;
using Saha.Services;

namespace Saha.Modals
{
    public partial class UpdateUserPage : ContentPage
    {

        private readonly SQLiteService _db;
        private AcceptUsersViewModel _viewModel;
        private UserModel _editingUser;
        public UpdateUserPage(UserModel userModel, AcceptUsersViewModel viewModel)
        {
            InitializeComponent();

            // Initialize the list of users
            // You can add some sample data here if needed
            // For example:

            _db = new SQLiteService();

            _viewModel = viewModel;
            _editingUser = userModel;

            BindingContext = _editingUser;
            //BindingContext = new AcceptUsersViewModel();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {

            string name = Fullname.Text?.Trim() ?? string.Empty;
            string email = Email.Text?.Trim() ?? string.Empty;
            int age = Age.Text != null ? int.Parse(Age.Text) : 0;
            string gender = Gender.SelectedItem?.ToString() ?? string.Empty;
            string fitnessGoal = FitnessGoal.SelectedItem?.ToString() ?? string.Empty;
            string phoneNumber = PhoneNumber.Text?.Trim() ?? string.Empty;
            string medicalCondition = MedicalCondition.Text?.Trim() ?? string.Empty;

            // 1. Validate Inputs
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(age.ToString()) ||
                string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(fitnessGoal) ||
                string.IsNullOrWhiteSpace(medicalCondition)
                )
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            UserModel user = new UserModel
            {
                FullName = name,
                Email = email,
                Password = _editingUser.Password, // Keep the original password
                PhoneNumber = phoneNumber,
                Age = age,
                Gender = gender,
                Role = fitnessGoal,
                MedicalCondition = medicalCondition

            };

            _db.UpdateUser(user); // Make sure you have this in your SQLiteService
            await DisplayAlert("Success", "User updated successfully", "OK");
            await Navigation.PopAsync();
        }








        public void OnDashboardClicked(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new UserListPage());
        }
        public void OnUsersClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new UserListPage());
        }
        public void OnRequestListClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RequestListPage());
        }
        public void OnReportsClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new SettingsPage());
        }
        public void OnSettingsClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new SettingsPage());
        }
        public void OnLogoutClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new LoginPage());
        }

    }
}
