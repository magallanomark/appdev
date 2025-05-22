using System.ComponentModel;
using System.Runtime.CompilerServices;

public class AttendanceRecord : INotifyPropertyChanged
{
    public int Id { get; set; }
    public int UserProgramId { get; set; }

    private DateTime _sessionDate;
    public DateTime SessionDate
    {
        get => _sessionDate;
        set { _sessionDate = value; OnPropertyChanged(); }
    }

    private bool _isPresent;
    public bool IsPresent
    {
        get => _isPresent;
        set { _isPresent = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
