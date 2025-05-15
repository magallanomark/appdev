using System;
using System.Collections.Generic;
using Saha.Admin;
using Saha.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Saha.ViewModel;

namespace Saha.Modals
{
    public partial class ViewUserPage : ContentPage
    {

      

    public ViewUserPage()
    {
        InitializeComponent();

        // Initialize the list of users
        // You can add some sample data here if needed
        // For example:
         BindingContext = new AcceptUsersViewModel();
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
