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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace CV19Main.ViewModels
{
    internal class CountryStatisticViewModel : ViewModel
    {
        private DataService _dataService;

        private MainWindowViewModel MainWindow { get; }


        #region Properties


        #region OxyPlot




        private PlotModel _model;
        public PlotModel model
        {
            get => _model;
            set => SetField(ref _model, value);

        }



        private LineSeries lineSeries;

        public LineSeries MyLineSeries
        {
            get => lineSeries;
            set => SetField(ref lineSeries, value);
        }

        #endregion

        #region IEnumerable<CountryInfo> Countries - cnfnbcnbrf gj cnhfyfv


        private IEnumerable<CountryInfo> _countries;

        public IEnumerable<CountryInfo> Countries
        {
            get => _countries;
            private set => SetField(ref _countries, value);
        }

        #endregion

        #region CountryInfo _selectedCountryInfo;

        void UpdateLineSeries()
        {

            MyLineSeries = new LineSeries
            {
                Title = "Line Series",
                MarkerType = MarkerType.Circle,
                StrokeThickness = 3,
                //MarkerStroke = OxyColors.Red,
                //MarkerStrokeThickness = 1,
                Color = OxyColors.Red,

            };
            var ttt = SelectedCountryInfo.Counts.ToList();
            for (int i = 0; i < SelectedCountryInfo.Counts.Count(); i++)
            {
                var xx = DateTimeAxis.CreateDataPoint(ttt[i].Date, ttt[i].Count);
                MyLineSeries.Points.Add(xx);
            }



            var axes = model.Axes;
            if (model.Series.Count != 0)
            {
                model.Series.Clear();
            }

            model.Series.Add(MyLineSeries);


            model.InvalidatePlot(true);
            model.Axes[0].Reset();
            model.Axes[1].Reset();
            //model.Axes.ToArray()[0].AbsoluteMinimum = 2018;
            //model.Axes.ToArray()[0].AbsoluteMaximum = 2024;
            //model.Axes.ToArray()[1].Maximum = 2030;
            //model.Axes.ToArray()[1].Minimum = 2019;
            //foreach (var aaAx in axes)
            //{
            //    aaAx.Reset();
            //}
        }

        private CountryInfo _selectedCountryInfo = new CountryInfo();

        public CountryInfo SelectedCountryInfo
        {
            get => _selectedCountryInfo;
            set
            {
                SetField(ref _selectedCountryInfo, value);
                UpdateLineSeries();
            }
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
                    Provinces = Enumerable.Range(1, 10)
                        .Select(j => new PlaceInfo()
                        {
                            Name = $"Province {j}",
                            Location = new PersonalPoint(i, j),
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

            model = new PlotModel();
            model.Axes.Add(new DateTimeAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dash,
                Title = "Дата",
                Position = AxisPosition.Bottom
            });
            model.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dash,
                Position = AxisPosition.Left,
                Title = "Число"
            }
            );


            MainWindow = mainWindow;

            _dataService = new DataService();

            #region Commands

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

            #endregion
        }

    }
}
