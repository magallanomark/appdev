using Saha.Services;
using System.Diagnostics;

namespace Saha;


public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        Routing.RegisterRoute("GuestViewPage", typeof(GuestViewPage));
        // Set the main page of the application
        // MainPage = new AppShell(); // Uncomment this if you want to use Shell navigation
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {

        Debug.WriteLine($"RoleSession.CurrentUserRole: {RoleSession.CurrentUserRole}");
        var role = RoleSession.CurrentUserRole?.ToString() ?? "Guest"; // fallback role
        return new Window(new AppShell(role));


    }
}
