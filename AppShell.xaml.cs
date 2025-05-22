using Saha.Admin;
using Saha.Services;
using Saha.Trainor;
using Saha.Customer;

namespace Saha;

public partial class AppShell : Shell
{
	public AppShell(string role)
	{
		InitializeComponent();

		// Clear any existing items
		this.Items.Clear();

		// Common pages for all users
		Routing.RegisterRoute(nameof(TrainerAttendancePage), typeof(TrainerAttendancePage));


		if (UserSession.CurrentUserId == 0 || string.IsNullOrEmpty(role))
		{
			Items.Add(new ShellContent
			{
				Title = "Home",
				ContentTemplate = new DataTemplate(typeof(GuestViewPage)),
				Icon = "login.png"
			});
		}


		if (role.Equals("admin", StringComparison.CurrentCultureIgnoreCase))
		{
			Items.Add(new ShellContent
			{
				Title = "Dashboard",
				ContentTemplate = new DataTemplate(typeof(AdminDashboardPage)),
				Icon = "icon_gym2.png"
			});
			Items.Add(new ShellContent
			{
				Title = "User Management",
				ContentTemplate = new DataTemplate(typeof(AdminUserManagement)),
				Icon = "admin.png"
			});
			Items.Add(new ShellContent
			{
				Title = "Programs",
				ContentTemplate = new DataTemplate(typeof(AdminProgram)),
				Icon = "settings.png"
			});
			Items.Add(new ShellContent
			{
				Title = "User Programs Requests",
				ContentTemplate = new DataTemplate(typeof(AdminUserProgram)),
				Icon = "settings.png"
			});
			Items.Add(new ShellContent
			{
				Title = "User Programs Reviewed",
				ContentTemplate = new DataTemplate(typeof(AdminUserProgramReviewed)),
				Icon = "settings.png"
			});

			FlyoutFooter = new StackLayout
			{
				Padding = 10,
				Children =
				{
					new Button
					{
						Text = "Logout",
						BackgroundColor = Colors.Red,
						TextColor = Colors.WhiteSmoke,
						FontAttributes = FontAttributes.Bold,
						BorderColor=Colors.LightGray,
						Command = new Command(() =>
						{
							RoleSession.CurrentUserRole = null;
							UserSession.CurrentUserId = 0;
							Application.Current.MainPage = new AppShell("guest");
						})
					}
				}
			};

		}
		else if (role.ToLower() == "customer")
		{
			Items.Add(new ShellContent
			{
				Title = "Dashboard",
				ContentTemplate = new DataTemplate(typeof(CustomerDashboard)),
				Icon = "home.png"
			});
			Items.Add(new ShellContent
			{
				Title = "Programs",
				ContentTemplate = new DataTemplate(typeof(CustomerProgram)),
				Icon = "programs.png"
			});
			FlyoutFooter = new StackLayout
			{
				Padding = 10,
				Children =
				{
					new Button
					{
						Text = "Logout",
						BackgroundColor = Colors.Red,
						TextColor = Colors.WhiteSmoke,
						FontAttributes = FontAttributes.Bold,
						BorderColor=Colors.LightGray,
						Command = new Command(() =>
						{
							RoleSession.CurrentUserRole = null;
							UserSession.CurrentUserId = 0;
							Application.Current.MainPage = new AppShell("guest");
						})
					}
				}
			};

		}
		else if (role.ToLower() == "trainer")
		{
			Items.Add(new ShellContent
			{
				Title = "Dashboard",
				ContentTemplate = new DataTemplate(typeof(TrainorDashboard)),
				Icon = "home.png"
			});
			Items.Add(new ShellContent
			{
				Title = "User Programs",
				ContentTemplate = new DataTemplate(typeof(TrainorUserProgram)),
				Icon = "home.png"
			});

			FlyoutFooter = new StackLayout
			{
				Padding = 10,
				Children =
				{
					new Button
					{
						Text = "Logout",
						BackgroundColor = Colors.Red,
						TextColor = Colors.WhiteSmoke,
						FontAttributes = FontAttributes.Bold,
						BorderColor=Colors.LightGray,
						Command = new Command(() =>
						{
							RoleSession.CurrentUserRole = null;
							UserSession.CurrentUserId = 0;
							Application.Current.MainPage = new AppShell("guest");
						})
					}
				}
			};
		}

		// Logout or settings page common to all

	}
}
