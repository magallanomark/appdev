using Saha.Models;
using Saha.Services;
using Saha.Trainor;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace Saha.ViewModel
{
    public class TrainorDashboardViewModel
    {


        SQLiteService db;
        public ObservableCollection<ProgramModel> AssignedPrograms { get; set; }

        public ObservableCollection<AttendanceRecord> AttendanceRecords { get; set; } = new();

        public ObservableCollection<ProgramModel> UserPrograms { get; set; }
        public ObservableCollection<UserModel> Trainers { get; set; }
        public ObservableCollection<DisplayProgramViewModel> MyPrograms { get; set; }
        public Command<UserProgram> NavigateToAttendanceCommand { get; }

        public static float progress = 0;

        public Command SaveCommand { get; }


        public TrainorDashboardViewModel()
        {

            db = new SQLiteService();
            SaveCommand = new Command(async () => await SaveAttendanceAsync());

            int userId = UserSession.CurrentUserId;

            AssignedPrograms = new ObservableCollection<ProgramModel>(db.GetProgramsByUserId(userId));
            //  var trainorPrograms = db.GetUserProgramsByTrainorId(userId);

            MyPrograms = new ObservableCollection<DisplayProgramViewModel>();

            var trainorPrograms = db.GetUserProgramsByTrainorId(userId);


            Debug.WriteLine($"Here - { trainorPrograms}");

            NavigateToAttendanceCommand = new Command<UserProgram>(NavigateToAttendance);

            foreach (var item in trainorPrograms)
            {
                foreach (var userProgram in item.UserPrograms)
                {
                    DateTime start = DateTime.Parse(userProgram.StartDate);
                    DateTime end = DateTime.Parse(userProgram.EndDate);
                    DateTime today = DateTime.Today;

                    double totalDays = (end - start).TotalDays;
                    double elapsedDays = (today - start).TotalDays;

                    // Clamp the value between 0.0 and 1.0
                    // =(double) userProgram.Progess / db.GetAttendanceRecordsByUserProgramId(RoleSession.UserProgramId).Count();
                    var records = db.GetAttendanceRecordsByUserProgramId(userProgram.Id);
                    int total = records.Count;
                    int presentCount = records.Count(r => r.IsPresent);

                    double Valprogress = total == 0 ? 0 : (double)presentCount / total;





                    MyPrograms.Add(new DisplayProgramViewModel
                    {
                        Name = item.Program.Name,
                        Description = item.Program.Description,
                        StartDate = start.ToString("MMMM dd, yyyy"),
                        EndDate = end.ToString("MMMM dd, yyyy"),
                        Progess = Valprogress,
                        OriginalUserProgram = userProgram // <-- Add this
                    });
                }
            }

           

        }


        public async Task SaveAttendanceAsync()
        {
            foreach (var record in AttendanceRecords)
            {
                db.UpdateAttendanceRecordPresence(record); // Update IsPresent in DB
            }

            await Application.Current.MainPage.DisplayAlert("Saved", "Attendance successfully updated!", "OK");
        }



        private async void NavigateToAttendance(UserProgram userProgram)
        {
            if (userProgram == null)
                return;

            Debug.WriteLine($"Navigating to attendance for user program ID: {userProgram.Id}");


            db.GetAttendanceRecordsByUserId(userProgram.Id);


            RoleSession.UserProgramId = userProgram.Id;


            await Shell.Current.GoToAsync(nameof(TrainerAttendancePage), true, new Dictionary<string, object>
            {
                { "SelectedUserProgram", userProgram }
            });

        }

        public void LoadPrograms()
        {
            // Load programs from the database or any other source

        }
        public class DisplayProgramViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public double Progess { get; set; } // As a decimal from 0.0 to 1.0

            public UserProgram OriginalUserProgram { get; set; } // <-- Add this
        }


        public async Task LoadAttendanceAsync(int userProgramId)
        {
            var records = db.GetAttendanceRecordsByUserProgramId(userProgramId);
            float countRec = records.Count(a => a.IsPresent);
            float countHe = records.Count();

            progress = countRec / countHe;




            int count = 0;

            AttendanceRecords.Clear();
            foreach (var record in records)
            {
                AttendanceRecords.Add(record);
                count++;
            }



            Debug.WriteLine($" Count === {progress}");


         

            db.UpdateUserProgramProgress(userProgramId, countRec); // Set progress to 5



        }


    }
}
