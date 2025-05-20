using System;
using System.Collections.Generic;
using Saha.Admin;
using Saha.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Saha.ViewModel;
using Saha.Services;

namespace Saha.Modals
{
    public partial class AddProgram : ContentPage
    {


        private readonly SQLiteService _db;


        public AddProgram()
        {
            InitializeComponent();

            // Initialize the list of users
            // You can add some sample data here if needed
            // For example:

            _db = new SQLiteService();

            BindingContext = new ProgramViewModel();

        }








        public async void OnSaveProgramClicked(object sender, EventArgs e)
        {
            string programName = ProgramNameEntry.Text?.Trim() ?? string.Empty;
            string programDescription = ProgramDescriptionEntry.Text?.Trim() ?? string.Empty;
            // string trainerName = TrainerPicker.Text?.Trim() ?? string.Empty;
            // string trainerName = TrainerPicker.SelectedItem?.ToString() ?? string.Empty;
            var selectedTrainer = TrainerPicker.SelectedItem as UserModel;
            int trainerId = selectedTrainer?.Id ?? 0;  // or any default int value (like 0) when null

            // For DatePicker, get Date and convert to string if needed

            int duration = DurationEntry.Text != null ? int.Parse(DurationEntry.Text) : 0;

            // For price Entry, still get Text (numeric string)
            string programPrice = PriceEntry.Text?.Trim() ?? string.Empty;



            //Debug.WriteLine($"Trainer Name: {trainerName}");

            // 1. Validate Inputs
            if (string.IsNullOrWhiteSpace(programName) ||
                string.IsNullOrWhiteSpace(programDescription) ||
                trainerId == 0 ||
                string.IsNullOrWhiteSpace(duration.ToString()) ||
                string.IsNullOrWhiteSpace(programPrice))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            // 2. Create a new ProgramModel object
            ProgramModel newProgram = new ProgramModel
            {
                Name = programName,
                Description = programDescription,
                Trainer_Id = trainerId,
                Price = programPrice,
                Duration = duration,
            };

            // 3. Save the new program to the database
            _db.AddProgram(newProgram);

            // 4. Optionally, navigate back or show a success message
            await DisplayAlert("Success", "Program added successfully!", "OK");

            await Navigation.PushAsync(new AdminProgram());
        }


    }
}
