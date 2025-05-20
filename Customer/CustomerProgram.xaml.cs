using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Saha.Admin;
using Saha.ViewModel;
using Saha.Models;
using Saha.Services;



namespace Saha.Customer
{
    public partial class CustomerProgram : ContentPage
    {


        private ProgramModel _selectedProgram;

        private SQLiteService _dbService;

        DateTime selectedDate;

        public ObservableCollection<UserProgram> UserPrograms { get; set; }
        public CustomerProgram()
        {
            InitializeComponent();

            BindingContext = new CustomerViewModels();

            _dbService = new SQLiteService();

        }


        public async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerDashboard());
        }
        public async void OnUsersClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AdminUserManagement());
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
