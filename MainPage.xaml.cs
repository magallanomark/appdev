using Microsoft.Maui.Controls;
using Saha;

namespace Saha
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Event handler for the "Register" button
        private async void OnRequestHelpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        // Event handler for the "Log In" button
        private async void OnVolunteerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        // Event handler for the "View as Guest" button
        private async void OnChatClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuestViewPage());
        }

        // Optional button press effect handlers
        private void OnButtonPressed(object sender, EventArgs e)
        {
            // You can handle any press effect here
        }

        private void OnButtonReleased(object sender, EventArgs e)
        {
            // You can handle any release effect here
        }
    }
}
