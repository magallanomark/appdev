using System;
using System.Collections.Generic;
using Saha.Admin;
using Saha.Modals;
using Saha.ViewModel;

namespace Saha.Admin
{
    public partial class AdminProgram : ContentPage
    {
        public AdminProgram()
        {
            InitializeComponent();

            BindingContext = new ProgramViewModel();
        }


        public void OnDashboardClicked(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new UserListPage());
        }
        public void OnUsersClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new UserListPage());
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
        public void OnLogoutClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new LoginPage());
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
