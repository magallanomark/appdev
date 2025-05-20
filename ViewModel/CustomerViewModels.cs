using System.Collections.ObjectModel;
using System.Windows.Input;
using Saha.Models;
using Saha.Services;

namespace Saha.ViewModel
{
    public class CustomerViewModels
    {
        private SQLiteService _dbService;


        public ObservableCollection<ProgramModel> Programs { get; set; }


        public CustomerViewModels()
        {
            _dbService = new SQLiteService();

            Programs = new ObservableCollection<ProgramModel>(_dbService.GetPrograms());


        }


    }
}
