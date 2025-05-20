using SQLite;
using Saha.Models;
using System.IO;
using System.Diagnostics;

namespace Saha.Services
{

    public static class RoleSession
    {
        public static string CurrentUserRole { get; set; }
    }
}