using System;
using System.Collections.Generic;
using Saha.Admin;
using Saha.Services;

namespace Saha.Admin
{
    public partial class AdminDashboardPage : ContentPage
    {
        public AdminDashboardPage()
        {
            InitializeComponent();
        }


        public void OnDashboardClicked(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new UserListPage());
        }
        public async void OnUsersClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminUserManagement());
        }
        public async void OnProgramListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminProgram());
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
            await Navigation.PushAsync(new GuestViewPage());
        }


        // 

    }
}
