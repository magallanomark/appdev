using System;
using System.Collections.Generic;
using Saha.Modals;

namespace Saha
{
    public partial class GuestViewPage : ContentPage
    {
        public GuestViewPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }


        void OnPointerEntered(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                // Hover up animation
                frame.TranslateTo(0, -5, 100);

                // Access the StackLayout and its Labels
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Beginner Program Colors
                        titleLabel.TextColor = Color.FromArgb("#FFD97706");
                        subtitleLabel.TextColor = Color.FromArgb("#FFFACC6B");
                    }
                }
            }
        }

        void OnPointerExited(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                // Reset to original position
                frame.TranslateTo(0, 0, 100);

                // Access the StackLayout and its Labels
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Original colors for Beginner Program
                        titleLabel.TextColor = Color.FromArgb("#FF514805");
                        subtitleLabel.TextColor = Color.FromArgb("#FFBAA72E");
                    }
                }
            }
        }

        void OnMusclePointerEntered(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, -5, 100);
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Muscle Building Colors
                        titleLabel.TextColor = Color.FromArgb("#C80000");
                        subtitleLabel.TextColor = Color.FromArgb("#FF7F7F");
                    }
                }
            }
        }

        void OnMusclePointerExited(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, 0, 100);
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Original colors for Muscle Building
                        titleLabel.TextColor = Color.FromArgb("#FF514805");
                        subtitleLabel.TextColor = Color.FromArgb("#FFBAA72E");
                    }
                }
            }
        }

        void OnFatLossPointerEntered(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, -5, 100);
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Fat Loss Colors
                        titleLabel.TextColor = Color.FromArgb("#1E90FF");
                        subtitleLabel.TextColor = Color.FromArgb("#87CEFA");
                    }
                }
            }
        }

        void OnFatLossPointerExited(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, 0, 100);
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Original colors for Fat Loss
                        titleLabel.TextColor = Color.FromArgb("#FF514805");
                        subtitleLabel.TextColor = Color.FromArgb("#FFBAA72E");
                    }
                }
            }
        }

        void OnStrengthPointerEntered(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, -5, 100);
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Strength Training Colors
                        titleLabel.TextColor = Color.FromArgb("#FF4500");
                        subtitleLabel.TextColor = Color.FromArgb("#FF6347");
                    }
                }
            }
        }

        void OnStrengthPointerExited(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, 0, 100);
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Original colors for Strength Training
                        titleLabel.TextColor = Color.FromArgb("#FF514805");
                        subtitleLabel.TextColor = Color.FromArgb("#FFBAA72E");
                    }
                }
            }
        }

        void OnHomePointerEntered(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, -5, 100);
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Home Workout Colors
                        titleLabel.TextColor = Color.FromArgb("#32CD32");
                        subtitleLabel.TextColor = Color.FromArgb("#98FB98");
                    }
                }
            }
        }

        void OnHomePointerExited(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                frame.TranslateTo(0, 0, 100);
                if (frame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Label titleLabel && stackLayout.Children[1] is Label subtitleLabel)
                    {
                        // Original colors for Home Workout
                        titleLabel.TextColor = Color.FromArgb("#FF514805");
                        subtitleLabel.TextColor = Color.FromArgb("#FFBAA72E");
                    }
                }
            }
        }




        private void OnBeginnerTapped(object sender, EventArgs e)
        {
            ShowPopup("Beginner Program", "Full-body beginner program, 3 days/week. Ideal for those just starting out.");
        }

        private void OnMuscleTapped(object sender, EventArgs e)
        {
            ShowPopup("Muscle Building", "Hypertrophy-focused program, 4 days/week. Designed to build muscle mass.");
        }

        private void OnFatLossTapped(object sender, EventArgs e)
        {
            ShowPopup("Fat Loss", "Cutting program for fat reduction, 3-4 days/week, includes cardio and HIIT.");
        }

        private void OnStrengthTapped(object sender, EventArgs e)
        {
            ShowPopup("Strength Training", "Powerlifting-style training, 4-5 days/week. Focus on compound lifts.");
        }

        private void OnHomeWorkoutTapped(object sender, EventArgs e)
        {
            ShowPopup("Home Workout", "Train at home with minimal equipment. 3 days/week, bodyweight focused.");
        }



        private void ShowPopup(string title, string message)
        {
            PopupTitle.Text = title;
            PopupMessage.Text = message;
            PopupOverlay.IsVisible = true;
        }

        private void ClosePopup(object sender, EventArgs e)
        {
            PopupOverlay.IsVisible = false;
        }


        // On Avail Clicked
        private async void OnAvailClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

    }
}
