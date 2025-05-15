using SQLite;
using Saha.Models;
using System.IO;
using System.Diagnostics;

namespace Saha.Services
{
    public class SQLiteService
    {
        private readonly SQLiteConnection _database;

        public SQLiteService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "appdata.db");

            Debug.WriteLine($"Database Path: {dbPath}");


            _database = new SQLiteConnection(dbPath);

            // Create both tables
            _database.CreateTable<UserModel>();
            _database.CreateTable<RequestUserModel>();
            _database.CreateTable<ProgramModel>();
        }

        // --- UserModel Methods ---
        public List<UserModel> GetUsers() => _database.Table<UserModel>().ToList();
        public void AddUser(UserModel user) => _database.Insert(user);

        public void UpdateUser(UserModel user) => _database.Update(user);
        public void DeleteUser(UserModel user) => _database.Delete(user);

        // --- RequestUserModel Methods ---
        public List<RequestUserModel> GetRequestUsers() => _database.Table<RequestUserModel>().ToList();
        public void AddRequestUser(RequestUserModel requestUser) => _database.Insert(requestUser);
        public void DeleteRequestUser(RequestUserModel requestUser) => _database.Delete(requestUser);


        // --- ProgramModel Methods ---
        public List<ProgramModel> GetPrograms() => _database.Table<ProgramModel>().ToList();
        public void AddProgram(ProgramModel program) => _database.Insert(program);
        public void UpdateProgram(ProgramModel program) => _database.Update(program);
        public void DeleteProgram(ProgramModel program) => _database.Delete(program);
    }
}
