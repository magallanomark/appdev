using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Saha.Admin;
using Saha.ViewModel;
using Saha.Models;
using Saha.Services;



namespace Saha.Customer
{
    public partial class CustomerDashboard : ContentPage
    {


        private ProgramModel _selectedProgram;

        private SQLiteService _dbService;

        public ObservableCollection<UserProgram> UserPrograms { get; set; }
        public CustomerDashboard()
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
            await Navigation.PushAsync(new GuestViewPage());
        }



        void OnHomePointerEntered(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, -5, 100);

                if (frame.Content is VerticalStackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel &&
                        stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Hover colors
                        titleLabel.TextColor = Color.FromArgb("#32CD32"); // Lime Green
                        subtitleLabel.TextColor = Color.FromArgb("#98FB98"); // Pale Green
                    }
                }
            }
        }

        void OnHomePointerExited(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, 0, 100);

                if (frame.Content is VerticalStackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel &&
                        stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Original colors
                        titleLabel.TextColor = Color.FromArgb("#FF514805"); // Brownish
                        subtitleLabel.TextColor = Color.FromArgb("#FFBAA72E"); // Yellow-orange
                    }
                }
            }
        }


        // 

        private void OnProgramTapped(object sender, TappedEventArgs e)
        {
            if (e.Parameter is ProgramModel selectedProgram)
            {
                ShowPopup(selectedProgram);
            }
        }

        private void ShowPopup(ProgramModel program)
        {
            _selectedProgram = program; // Store the selected program for later use
            PopupTitle.Text = program.Name;
            PopupMessage.Text = $"{program.Description}\n\nSchedule: {program.Schedule}\nPrice: {program.Price}";
            PopupOverlay.IsVisible = true;
        }

        private void ClosePopup(object sender, EventArgs e)
        {
            PopupOverlay.IsVisible = false;
        }


        private async void OnAvailClicked(object sender, EventArgs e)
        {

            if (_selectedProgram == null)
            {
                await DisplayAlert("Error", "Please select a program first.", "OK");
                return;
            }
            // Console.WriteLine($"User availed: {_selectedProgram.Name}");

            PopupOverlay.IsVisible = false;
            CalendarPopupOverlay.IsVisible = true;





            // Optional: Close the popup after availing
            PopupOverlay.IsVisible = false;
        }
        async void OnDateConfirmed(object sender, EventArgs e)
        {
            DateTime selectedDate = SelectedDatePicker.Date;


            var userProgram = new UserProgram
            {
                UserId = UserSession.CurrentUserId,
                ProgramId = _selectedProgram.Id,
                Progess = 0,
                StartDate = selectedDate.ToString("MM/dd/yyyy"),
            };

            _dbService.AddUserProgram(userProgram);

            // Example logic to store or show confirmation
            await DisplayAlert("Booking Confirmed",
                $"You availed {_selectedProgram?.Name} on {selectedDate:MMMM dd, yyyy}",
                "OK");





            // Hide the calendar popup
            CalendarPopupOverlay.IsVisible = false;

            // Optionally: save to DB or call API
        }


        void CloseCalendarPopup(object sender, EventArgs e)
        {
            CalendarPopupOverlay.IsVisible = false;
        }


    }
}
