using System;
using System.Collections.Generic;
using Saha.Trainor;
using Saha.Admin;
using Saha.Models;
using Saha.ViewModel;
using Saha.Trainor;
using Saha.Services;

namespace Saha.Trainor
{
    public partial class TrainorDashboard : ContentPage
    {
        public TrainorDashboard()
        {
            InitializeComponent();

            BindingContext = new TrainorDashboardViewModel();
        }


        public async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrainorDashboard());
        }
        public async void OnUsersClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminUserManagement());
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
        public async void OnLogoutClicked(object sender, EventArgs e)
        {
            UserSession.CurrentUserId = 0; // Reset the user ID
            await Navigation.PushAsync(new GuestViewPage());
        }



    }
}
