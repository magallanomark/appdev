using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Saha.Models;
using Saha.Services;

namespace Saha.ViewModel;

public class AcceptUsersViewModel
{
    public ObservableCollection<UserModel> AcceptedUsers { get; }


    public ICommand ViewCommand { get; }
    public ICommand DeleteCommand { get; }

    public AcceptUsersViewModel()
    {
       
        AcceptedUsers = UserStore.AcceptedUsers;

        ViewCommand = new Command<UserModel>(OnAcceptUser);
        DeleteCommand = new Command<UserModel>(OnDeleteUser);
    }

    private void OnAcceptUser(UserModel user)
    {
        if (user == null)
            return;

        if (AcceptedUsers.Contains(user))
        {
            AcceptedUsers.Remove(user);
            UserStore.AcceptedUsers.Add(user);       

        }
    }

    private void OnDeleteUser(UserModel user)
    {
        if (user != null && AcceptedUsers.Contains(user))
        {
            AcceptedUsers.Remove(user);
            Debug.WriteLine($"Deleted: {user.FullName}");
        }
    }
}
