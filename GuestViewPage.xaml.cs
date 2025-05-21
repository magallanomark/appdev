using System;
using System.Collections.Generic;
using Saha.Modals;
using Saha.Services;

namespace Saha
{
    public partial class GuestViewPage : ContentPage
    {
        public GuestViewPage()
        {
            InitializeComponent();
            //Clear user session
            // UserSession.CurrentUserId = 0;
            // RoleSession.CurrentUserRole = null;

            // // Replace shell with guest view
            // Application.Current.Windows[0].Page = new AppShell("guest");
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




    }
}
