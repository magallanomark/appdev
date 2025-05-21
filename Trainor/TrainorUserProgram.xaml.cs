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
    public partial class TrainorUserProgram : ContentPage
    {
        public TrainorUserProgram()
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
            RoleSession.CurrentUserRole = null;
            UserSession.CurrentUserId = 0;
            Application.Current.MainPage = new AppShell("guest");
            //await Navigation.PushAsync(new GuestViewPage());
        }



    }
}
