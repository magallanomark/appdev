namespace Saha;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Set the main page of the application
        // MainPage = new AppShell(); // Uncomment this if you want to use Shell navigation
		
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
