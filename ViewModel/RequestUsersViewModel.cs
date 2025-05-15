using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Saha.Models;
using Saha.Services;

namespace Saha.ViewModel;

public class RequestUsersViewModel
{
    public ObservableCollection<UserModel> RequestedUsers { get; }


    public ICommand ViewCommand { get; }
    public ICommand DeleteCommand { get; }

    public RequestUsersViewModel()
    {
        //Users = new ObservableCollection<UserModel>(userList ?? new List<UserModel>());
        RequestedUsers = UserStore.RequestedUsers;

        ViewCommand = new Command<UserModel>(OnAcceptUser);
        DeleteCommand = new Command<UserModel>(OnDeleteUser);
    }

    private void OnAcceptUser(UserModel user)
    {
        if (user == null)
            return;

        if (RequestedUsers.Contains(user))
        {
            RequestedUsers.Remove(user);
            UserStore.AcceptedUsers.Add(user);       

        }
    }

    private void OnDeleteUser(UserModel user)
    {
        if (user != null && RequestedUsers.Contains(user))
        {
            RequestedUsers.Remove(user);
            Debug.WriteLine($"Deleted: {user.FullName}");
        }
    }
}
