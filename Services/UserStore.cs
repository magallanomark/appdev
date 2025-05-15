using System.Collections.ObjectModel;
using Saha.Models;

namespace Saha.Services
{
    public static class UserStore
    {
        // Requested users list
        public static ObservableCollection<UserModel> RequestedUsers { get; set; } = new ObservableCollection<UserModel>();

        // Accepted users list
        public static ObservableCollection<UserModel> AcceptedUsers { get; set; } = new ObservableCollection<UserModel>();
        
    }
}
