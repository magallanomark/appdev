using SQLite;
using Saha.Models;
using System.IO;
using System.Diagnostics;

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
                _database.CreateTable<UserProgram>();
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
                        .Where(p => p.Status == "Approved" || p.Status == "Rejected")
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

        public void AddUserProgram(UserProgram userProgram)
        {
            lock (_lock)
            {
                _database.Insert(userProgram);
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






    }
}
