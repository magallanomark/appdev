using Microsoft.Maui.Controls;
using System;
using System.Diagnostics; // For Debug.WriteLine
using Saha.Models; // Assuming UserModel is in Saha.Models
using Saha.Admin;
using System.Linq; // To use LINQ for finding the user in the list
using System.Collections.Generic; // For List<T>
using Saha.Services; // For UserStore
using Saha.Trainor;
using Saha.Customer;

namespace Saha
{
    public partial class LoginPage : ContentPage
    {
        // Access the static list of users from RegisterPage
        public static List<UserModel> _userList = RegisterPage.UserList;  // Reference the same list used in RegisterPage

        SQLiteService _db;

        public LoginPage()
        {
            InitializeComponent();
            _db = new SQLiteService();

        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string emailFromUI = emailEntry.Text.ToString();
            string passwordFromUI = passwordEntry.Text.ToString();




            if (emailFromUI == null || passwordFromUI == null)
            {
                Debug.WriteLine("ERROR: Email or password entry field is null in C#. Check x:Name attributes in XAML.");
                await DisplayAlert("Input Error", "Could not read input fields.", "OK");
                return;
            }

            if (emailFromUI == "admin" && passwordFromUI == "admin")
            {
                RoleSession.CurrentUserRole = "Admin";
                UserSession.CurrentUserId = 999999; // Assuming admin has ID 1
                Debug.WriteLine($"RoleSession.CurrentUserRole: {RoleSession.CurrentUserRole.ToLower()}");

                //  await Navigation.PushAsync(new AdminDashboardPage());
                Application.Current.Windows[0].Page = new AppShell("admin");
                return;
            }
            string processedEmail = emailFromUI.Trim();
            string processedPassword = passwordFromUI; // For this test, direct use. Real passwords shouldn't typically be trimmed if spaces are significant.


            // Try to find the user in the static list
            var user = _db.GetUsers().FirstOrDefault(u => u.Email.Equals(emailFromUI, StringComparison.OrdinalIgnoreCase));


            //var user = _userList.FirstOrDefault(u => u.Email.Equals(processedEmail, StringComparison.OrdinalIgnoreCase));

            if (user != null && user.Password == processedPassword && user.Role.Equals("Trainer", StringComparison.OrdinalIgnoreCase))  // In a real app, compare the hashed password!
            {
                //Application.Current.MainPage = new AppShell(user.Role);
                Debug.WriteLine("Login Successful!");
                await DisplayAlert("Login Success", "Welcome back!", "OK");

                RoleSession.CurrentUserRole = user.Role;



                UserSession.CurrentUserId = user.Id; // Store the logged-in user in a session or static variable
                                                     // TODO: Navigate to the main app page after login success
                                                     // Example for MAUI Shell

                Application.Current.Windows[0].Page = new AppShell("trainer");
                Debug.WriteLine($"RoleSession.CurrentUserRole: {RoleSession.CurrentUserRole}");


                Debug.WriteLine($"User ID: {UserSession.CurrentUserId}");
                //await Navigation.PushAsync(new TrainorDashboard());

            }
            else if (user != null && user.Password == processedPassword && user.Role.Equals("Customer", StringComparison.OrdinalIgnoreCase))  // In a real app, compare the hashed password!
            {
                Debug.WriteLine("Login Successful!");
                await DisplayAlert("Login Success", "Welcome back!", "OK");

                UserSession.CurrentUserId = user.Id;
                RoleSession.CurrentUserRole = user.Role;
                Application.Current.Windows[0].Page = new AppShell("customer");
                Debug.WriteLine($"RoleSession.CurrentUserRole: {RoleSession.CurrentUserRole}");
                // await Navigation.PushAsync(new CustomerDashboard());
                // Store the logged-in user in a session or static variable
            }
            else
            {
                string errorMessage = "Invalid email or password. Please try again.";
                if (user == null)
                {
                    errorMessage = $"The email entered ('{processedEmail}') does not match our records. Check for typos.";
                }
                else if (user != null && user.Password != processedPassword)
                {
                    errorMessage = "The password entered is incorrect. Remember it's case-sensitive.";
                }

                Debug.WriteLine($"Login Failed: {errorMessage}");
                await DisplayAlert("Login Failed", errorMessage, "OK");
            }
        }

        private async void OnForgotPasswordTapped(object sender, TappedEventArgs e)
        {
            Debug.WriteLine("Forgot Password link tapped.");
            await DisplayAlert("Forgot Password", "This feature is not yet implemented.", "OK");
        }

        private async void OnSignUpTapped(object sender, TappedEventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());

        }
    }
}
