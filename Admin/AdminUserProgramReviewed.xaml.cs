using System;
using System.Collections.Generic;
using Saha.Admin;
using Saha.Modals;
using Saha.ViewModel;
using Saha.Services;

namespace Saha.Admin
{
    public partial class AdminUserProgramReviewed : ContentPage
    {
        public AdminUserProgramReviewed()
        {
            InitializeComponent();

            BindingContext = new ProgramViewModel();
        }


        public async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminDashboardPage());
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


        //User Management
        private async void OnAddProgramClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddProgram());
        }
        private async void OnEditUserClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AddUserPage());
        }
        private async void OnViewUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewUserPage());
        }

    }
}
