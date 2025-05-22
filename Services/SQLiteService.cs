using Saha.Models;
using SQLite;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace Saha.Services
{
    public class SQLiteService
    {
        private readonly SQLiteConnection _database;
        private readonly object _lock = new object(); // Lock object for synchronization



        public SQLiteService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "appdata.db");
            Debug.WriteLine($"Database Path: {dbPath}");
            _database = new SQLiteConnection(dbPath);

            // Create tables
            lock (_lock)
            {
                _database.CreateTable<UserModel>();
                _database.CreateTable<RequestUserModel>();
                _database.CreateTable<ProgramModel>();
                _database.CreateTable<UserProgram>();
                // _database.CreateTable<UserProgram>();
                _database.CreateTable<AttendanceRecord>();
            }
        }

        // --- UserModel Methods ---
        public List<UserModel> GetUsers()
        {
            lock (_lock)
            {
                return _database.Table<UserModel>().ToList();
            }
        }
        public List<UserModel> GetTrainors()
        {
            lock (_lock)
            {
                return _database.Table<UserModel>().Where(u => u.Role.ToLower() == "trainer").ToList();
            }
        }

        public List<ProgramWithTrainer> GetProgramsWithTrainer()
        {
            var programs = _database.Table<ProgramModel>().ToList();
            var users = _database.Table<UserModel>().ToList();

            var result = programs.Select(p =>
            {
                var trainer = users.FirstOrDefault(u => u.Id == p.Trainer_Id);
                return new ProgramWithTrainer
                {
                    Program = p,
                    Trainer = trainer
                };
            }).ToList();

            return result;
        }



        public void AddUser(UserModel user)
        {
            lock (_lock)
            {
                _database.Insert(user);
            }
        }
        public void UpdateUser(UserModel user)
        {
            lock (_lock)
            {
                _database.Update(user);
            }
        }
        public void DeleteUser(UserModel user)
        {
            lock (_lock)
            {
                _database.Delete(user);
            }
        }

        // --- RequestUserModel Methods ---
        public List<RequestUserModel> GetRequestUsers()
        {
            lock (_lock)
            {
                return _database.Table<RequestUserModel>().ToList();
            }
        }
        public void AddRequestUser(RequestUserModel requestUser)
        {
            lock (_lock)
            {
                _database.Insert(requestUser);
            }
        }
        public void DeleteRequestUser(RequestUserModel requestUser)
        {
            lock (_lock)
            {
                _database.Delete(requestUser);
            }
        }

        // --- ProgramModel Methods ---
        public List<ProgramModel> GetPrograms()
        {
            lock (_lock)
            {
                return _database.Table<ProgramModel>().ToList();
            }
        }

        public List<ProgramModel> GetAvailableProgramsByCustomer(int userId)
        {
            lock (_lock)
            {
                // Get all programs
                var allPrograms = _database.Table<ProgramModel>().ToList();

                // Get only the ProgramIds already assigned to this specific user
                var userProgramIds = _database.Table<UserProgram>()
                                              .Where(up => up.UserId == userId)
                                              .Select(up => up.ProgramId)
                                              .Distinct()
                                              .ToList();

                // Return programs not yet assigned to the user
                return allPrograms.Where(p => !userProgramIds.Contains(p.Id)).ToList();
            }
        }

        public void AddProgram(ProgramModel program)
        {
            lock (_lock)
            {
                _database.Insert(program);
            }
        }
        public void UpdateProgram(ProgramModel program)
        {
            lock (_lock)
            {
                _database.Update(program);
            }
        }
        public void DeleteProgram(ProgramModel program)
        {
            lock (_lock)
            {
                _database.Delete(program);
            }
        }

        // --- UserProgram Methods ---
        public List<UserProgram> GetUserPrograms()
        {
            lock (_lock)
            {
                return _database.Table<UserProgram>()
                        .Where(p => p.Status == "Pending")
                        .ToList();
            }
        }
        public List<UserProgram> GetUserAllPrograms()
        {
            lock (_lock)
            {
                return _database.Table<UserProgram>()
                        .Where(p => p.Status == "Accepted" || p.Status == "Rejected")
                        .ToList();
            }
        }


        public List<UserProgram> GetUserProgramsByUserId(int userId)
        {
            lock (_lock)
            {
                var userPrograms = _database.Table<UserProgram>().Where(up => up.UserId == userId).ToList();

                foreach (var up in userPrograms)
                {
                    // Load the Program
                    up.Program = _database.Table<ProgramModel>().FirstOrDefault(p => p.Id == up.ProgramId);

                    // Load the Trainer via the Program
                    if (up.Program != null)
                    {
                        up.Trainer = _database.Table<UserModel>().FirstOrDefault(t => t.Id == up.Program.Trainer_Id);
                    }
                }

                return userPrograms;
            }
        }

        // This class groups the program with its user programs
        public class ProgramWithUserPrograms
        {
            public ProgramModel Program { get; set; }
            public List<UserProgram> UserPrograms { get; set; }
        }

        // Method to get all programs created by the trainor with associated user programs
        public List<ProgramWithUserPrograms> GetUserProgramsByTrainorId(int trainorId)
        {
            lock (_lock)
            {
                var trainorPrograms = _database.Table<ProgramModel>()
                                               .Where(p => p.Trainer_Id == trainorId)
                                               .ToList();

                var result = new List<ProgramWithUserPrograms>();

                foreach (var program in trainorPrograms)
                {
                    var userPrograms = _database.Table<UserProgram>()
                                                .Where(up => up.ProgramId == program.Id)
                                                .ToList();

                    result.Add(new ProgramWithUserPrograms
                    {
                        Program = program,
                        UserPrograms = userPrograms
                    });
                }

                return result;
            }
        }




        public void UpdateUserProgram(UserProgram userProgram)
        {
            lock (_lock)
            {
                var rowsAffected = _database.Update(userProgram);
                Debug.WriteLine($"Rows affected: {rowsAffected}");
            }
        }

        public void DeleteUserProgram(List<UserProgram> userPrograms)
        {
            lock (_lock)
            {

                _database.Delete(userPrograms);

            }
        }

        public int AddUserProgram(UserProgram userProgram)
        {
            lock (_lock)
            {
                _database.Insert(userProgram);
                return userProgram.Id; // This will now contain the auto-incremented ID
            }
        }


        public void DeleteUserProgram(UserProgram userProgram)
        {
            lock (_lock)
            {
                _database.Delete(userProgram);
            }
        }


        public List<ProgramModel> GetProgramsByUserId(int userId)
        {
            lock (_lock)
            {
                return _database.Table<ProgramModel>().Where(up => up.Trainer_Id == userId).ToList();
            }
        }

        public List<UserModel> GetUsersByProgramId(int programId)
        {
            lock (_lock)
            {
                var userProgramLinks = _database.Table<UserProgram>().Where(up => up.ProgramId == programId).ToList();
                var userIds = userProgramLinks.Select(up => up.UserId).ToList();
                return _database.Table<UserModel>().Where(u => userIds.Contains(u.Id)).ToList();
            }
        }



        //Attendance
        public void CreateInitialAttendance(int userProgramId, List<DateTime> sessionDates)
        {
            lock (_lock)
            {
                foreach (var date in sessionDates)
                {
                    var attendance = new AttendanceRecord
                    {
                        UserProgramId = userProgramId,
                        SessionDate = date,
                        IsPresent = false // default
                    };

                    _database.Insert(attendance);
                }
            }
        }
        public void DeleteAttendanceByUserProgramId(int userProgramId)
        {
            lock (_lock)
            {
                _database.Execute("DELETE FROM AttendanceRecord WHERE UserProgramId = ?", userProgramId);
            }
        }

        public void UpdateAttendanceRecordPresence(AttendanceRecord record)
        {
            lock (_lock)
            {
                _database.Execute(
                    "UPDATE AttendanceRecord SET IsPresent = ? WHERE Id = ?",
                    record.IsPresent ? 1 : 0,
                    record.Id
                );
            }
        }


        public List<AttendanceRecord> GetAttendanceRecordsByUserId(int userId)
        {
            lock (_lock)
            {
                // Step 1: Get all user program IDs for this user
                var userProgramIds = _database.Table<UserProgram>()
                                              .Where(up => up.UserId == userId)
                                              .Select(up => up.Id)
                                              .ToList();

                // Step 2: Get all attendance records where UserProgramId matches
                return _database.Table<AttendanceRecord>()
                                .Where(ar => userProgramIds.Contains(ar.UserProgramId))
                                .ToList();
            }
        }



        public void UpdateAttendanceRecordPresence(int id, bool isPresent)
        {
            lock (_lock)
            {
                var record = _database.Table<AttendanceRecord>().FirstOrDefault(a => a.Id == id);
                if (record != null)
                {
                    record.IsPresent = isPresent;
                    _database.Update(record);
                }
            }
        }


        public ObservableCollection<AttendanceRecord> GetAttendanceRecordsByUserProgramId(int userProgramId)
        {
            lock (_lock)
            {
                var list = _database.Table<AttendanceRecord>()
                                    .Where(a => a.UserProgramId == userProgramId)
                                    .ToList();

                return new ObservableCollection<AttendanceRecord>(list);
            }
        }


        public void UpdateUserProgramProgress(int userProgramId, float newProgress)
        {
            lock (_lock)
            {
                var program = _database.Table<UserProgram>().FirstOrDefault(up => up.Id == userProgramId);
                if (program != null)
                {
                    program.Progress = newProgress; // Note: double-check your spelling if it's really "Progess"
                    _database.Update(program);
                }
            }
        }




        //public List<AttendanceRecord> GetAttendanceRecordsByUserProgramId(int userProgramId)
        //{
        //    lock (_lock)
        //    {
        //        return _database.Table<AttendanceRecord>()
        //                        .Where(a => a.UserProgramId == userProgramId)
        //                        .ToList();
        //    }
        //}




    }
}
