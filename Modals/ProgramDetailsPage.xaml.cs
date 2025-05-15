namespace Saha.Modals;

public partial class ProgramDetailsPage : ContentPage
{
    public ProgramDetailsPage(string programName, string description)
    {
        InitializeComponent();
        Title = programName;
        ProgramDescriptionLabel.Text = description;
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
