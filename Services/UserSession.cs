using SQLite;
using Saha.Models;
using System.IO;
using System.Diagnostics;

namespace Saha.Services
{

    public static class UserSession
    {
        public static int CurrentUserId { get; set; }
    }
}