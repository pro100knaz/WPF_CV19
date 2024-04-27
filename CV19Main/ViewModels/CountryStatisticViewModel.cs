using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CV19Main.Infrastructure.Commands;
using CV19Main.Models;
using CV19Main.Services;
using CV19Main.ViewModels.Base;

namespace CV19Main.ViewModels
{
    internal class CountryStatisticViewModel :ViewModel
    {
        private DataService _dataService;

        private  MainWindowViewModel MainWindow { get; }


        #region Properties

        #region IEnumerable<CountryInfo> Countries - cnfnbcnbrf gj cnhfyfv


            private IEnumerable<CountryInfo> _countries;

            public IEnumerable<CountryInfo> Countries
            {
                get => _countries;
                private set => SetField(ref _countries, value);
            }

        #endregion


        #endregion


        #region Commands

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _dataService.GetData();
        }

        #endregion

        #region Отладочный Конструктор

            public CountryStatisticViewModel() : this(null)
            {
                if (!App.IsDesignMode)
                    throw new InvalidOperationException("ИДИИИИИИИИИИИИИИИИИ НАХУЙЙЙЙЙЙЙЙЙ");

                Countries = Enumerable.Range(1, 10)
                    .Select(i => new CountryInfo()
                    {
                        Name = $"Country Number {i}",
                        ProvinceCounts = Enumerable.Range(1,10)
                            .Select(j => new PlaceInfo()
                            {
                                Name = $"Province {j}",
                                Location = new PersonalPoint(i,j),
                                Counts = Enumerable.Range(1, 10).Select(k => new ConfirmedCount()
                                {
                                    Date = DateTime.Now.Subtract(TimeSpan.FromDays(100 - k)),
                                    Count = k
                                }).ToArray()
                            }).ToArray()
                    }).ToArray();
            }
        

        #endregion
        public CountryStatisticViewModel(MainWindowViewModel mainWindow)
        {

             MainWindow = mainWindow;

            _dataService = new DataService();

            #region Commands

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

            #endregion
        }

    }
}
