using Saha.Models; // Assuming UserModel is in Saha.Models
using System.Text.RegularExpressions; // For email validation
using System;
using System.Collections.Generic;
using Saha.Services;

namespace Saha
{
    public partial class RegisterPage : ContentPage
    {
        // Static list to store users
         public static List<UserModel> UserList = new List<UserModel>();

        public static List<UserModel> RequestUser = new List<UserModel>();
        private SQLiteService _db = new SQLiteService();


        public RegisterPage()
        {
            InitializeComponent();

        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text?.Trim() ?? string.Empty;
            string email = emailEntry.Text?.Trim() ?? string.Empty;
            string password = passwordEntry.Text ?? string.Empty;
            string confirmPassword = confirmPasswordEntry.Text ?? string.Empty;
            bool isTermsChecked = termsCheckBox.IsChecked;
            int age = ageEntry.Text != null ? int.Parse(ageEntry.Text) : 0;
            string gender = genderPicker.SelectedItem?.ToString() ?? string.Empty;
            string fitnessGoal = fitnessGoalPicker.SelectedItem?.ToString() ?? string.Empty;
            string phoneNumber = phoneEntry.Text?.Trim() ?? string.Empty;
            string medicalCondition = medicalConditionsEntry.Text?.Trim() ?? string.Empty;

            // 1. Validate Inputs
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword)||
                string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(age.ToString()) ||
                string.IsNullOrWhiteSpace(gender)||
                string.IsNullOrWhiteSpace(fitnessGoal)||
                string.IsNullOrWhiteSpace(medicalCondition) 
                )
                {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            if (!IsValidEmail(email))
            {
                await DisplayAlert("Error", "Please enter a valid email address.", "OK");
                return;
            }

            if (password.Length < 6)
            {
                await DisplayAlert("Error", "Password must be at least 6 characters long.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            if (!termsCheckBox.IsChecked)
            {
                await DisplayAlert("Error", "You must agree to the Terms and Conditions.", "OK");
                return;
            }

          
            RequestUserModel newUser = new RequestUserModel
            {
                FullName = name,
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                Age = age,
                Gender = gender,
                FitnessGoal = fitnessGoal,
                MedicalCondition = medicalCondition

            };

           // UserStore.RequestedUsers.Add(newUser);

            _db.AddRequestUser(newUser);
            //RequestUser.Add(newUser);


            await DisplayAlert("Success", "User registered successfully!", "OK");


            // Navigate to the login page
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnTermsAndConditionsTapped(object sender, EventArgs e)
        {
            // For a real app, navigate to a dedicated T&C page or show a scrollable view.
            // For simplicity, we'll use DisplayAlert.
            string terms = @"
Gym MS App - Terms and Conditions

1. Acceptance of Terms: By creating an account and using the Gym MS App services, you agree to be bound by these Terms and Conditions.

2. Membership & Access:
   - You must be 18 years or older or have parental consent.
   - Your account is personal and non-transferable.
   - We reserve the right to terminate or suspend access for violation of these terms.

3. User Conduct:
   - You agree not to use the app for any unlawful purpose.
   - Respect other users and gym staff.
   - Follow all posted gym rules and regulations when on premises.

4. Payments and Fees:
   - Details of membership fees, payment schedules, and refund policies will be provided separately.

5. Data Privacy:
   - We collect personal data as described in our Privacy Policy.
   - We use data to provide and improve our services.

6. Limitation of Liability:
   - Use of the gym facilities and app is at your own risk.
   - We are not liable for any personal injury or loss of property.

7. Changes to Terms:
   - We may update these terms from time to time. Continued use of the app after changes constitutes acceptance.
";
            await DisplayAlert("Terms and Conditions", terms, "OK");
        }

        private async void OnLoginLinkTapped(object sender, EventArgs e)
        {
            // Navigate to LoginPage (Assuming LoginPage is registered in AppShell.xaml)
            // The "//" ensures navigation from the root of the shell hierarchy.
            await Shell.Current.GoToAsync("//LoginPage");
        }

        // Basic Email Validation Helper
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Use a simple regex for basic format checking.
                // For more robust validation, consider a library or more complex regex.
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
