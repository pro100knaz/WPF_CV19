using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Services;
using CV19Main.ViewModels.Base;

namespace CV19Main.ViewModels
{
    internal class CountryStatisticViewModel :ViewModel
    {
        private DataService _dataService;

        private  MainWindowViewModel MainWindow { get; }

        public CountryStatisticViewModel(MainWindowViewModel mainWindow)
        {
             MainWindow = mainWindow;

            _dataService = new DataService();

        }

    }
}
