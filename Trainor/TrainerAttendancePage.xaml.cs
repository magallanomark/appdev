using Saha.Models;
using Saha.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using Saha.Services;

namespace Saha.Trainor;

public partial class TrainerAttendancePage : ContentPage, IQueryAttributable
{
    private TrainorDashboardViewModel viewModel;

    public TrainerAttendancePage()
    {
        InitializeComponent();
        viewModel = new TrainorDashboardViewModel();
        
        BindingContext = viewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("SelectedUserProgram", out var selected) && selected is UserProgram userProgram)
        {
            // Load attendance based on passed userProgram


            viewModel.LoadAttendanceAsync(RoleSession.UserProgramId);

        }

        //if (query.TryGetValue("AttendanceCount", out var countValue) && countValue is int count)
        //{
        //    viewModel.AttendanceCount = count;
        //}
    }
}
