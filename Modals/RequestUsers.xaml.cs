using System;
using System.Collections.Generic;
using Saha.Admin;
using Saha.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Saha.ViewModel;

namespace Saha.Modals
{
    public partial class RequestUsers : ContentPage
    {

      

    public RequestUsers()
    {
        InitializeComponent();

        // Initialize the list of users
        // You can add some sample data here if needed
        // For example:
         BindingContext = new RequestUsersViewModel();
    }


        private void OnUserTapped(object sender, EventArgs e)
        {
            if (sender is Grid grid && grid.BindingContext is RequestUserModel user)
            {
                PopupTitle.Text = user.FullName;
                PopupEmail.Text = $"Email: {user.Email}";
                PopupPhone.Text = $"Phone: {user.PhoneNumber}";
                PopupAge.Text = $"Age: {user.Age}";
                PopupGender.Text = $"Gender: {user.Gender}";
                PopupGoal.Text = $"Goal: {user.FitnessGoal}";
                PopupMedical.Text = $"Medical: {user.MedicalCondition}";
                PopupRole.Text = $"Role: {user.Role}";
                PopupOverlay.IsVisible = true;
            }
        }

        private void ClosePopup(object sender, EventArgs e)
        {
            PopupOverlay.IsVisible = false;
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


        //User Management
        private async void OnViewRequestsClicked(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new AddUserPage());
        }
        private async void OnEditUserClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AddUserPage());
        }
        private async void OnAddUserClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AddUserPage());
        }
       
    }
}
