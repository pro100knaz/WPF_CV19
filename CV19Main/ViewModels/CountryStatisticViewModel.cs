using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CV19Main.Infrastructure.Commands;
using CV19Main.Models;
using CV19Main.Services;
using CV19Main.Services.Interfaces;
using CV19Main.ViewModels.Base;
using MapControl;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace CV19Main.ViewModels
{
    internal class CountryStatisticViewModel : ViewModel
    {
        private readonly IDataService _dataService;

        public MainWindowViewModel MainModel { get; internal set; }


        #region Properties

        #region MapSettings

        private MapProjection currentProjection;
        public MapProjection CurrentProjection
        {
            get => currentProjection;
            set
            {
                SetField(ref currentProjection, value);
            }
        }


        private IMapLayer currentLayer;
        public IMapLayer CurrentLayer
        {
            get => currentLayer;
            set
            {
                SetField(ref currentLayer, value);
            }
        }

        private Location pushpinLocation;
        public Location PushpinLocation
        {
            get => pushpinLocation;
            set
            {
                SetField(ref pushpinLocation, value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(PushpinText));
            }
        }
        public string PushpinText
        {
            get
            {
                if (SelectedCountryInfo.Location == null)
                {
                    return "Choose The Country";
                }
                var latitude = (int)Math.Round(PushpinLocation.Latitude * 36000);
                var longitude = (int)Math.Round(Location.NormalizeLongitude(PushpinLocation.Longitude) * 36000);
                var latHemisphere = 'N';
                var lonHemisphere = 'E';

                if (latitude < 0)
                {
                    latitude = -latitude;
                    latHemisphere = 'S';
                }

                if (longitude < 0)
                {
                    longitude = -longitude;
                    lonHemisphere = 'W';
                }

                return string.Format(CultureInfo.InvariantCulture,
                    "{0}  {1:00} {2:00} {3:00.0}\n{4} {5:000} {6:00} {7:00.0}",
                    latHemisphere, latitude / 36000, (latitude / 600) % 60, (latitude % 600) / 10d,
                    lonHemisphere, longitude / 36000, (longitude / 600) % 60, (longitude % 600) / 10d);
            }
        }

        public List<MapProjection> Projections { get; } = new List<MapProjection>();

        public Dictionary<string, IMapLayer> Layers { get; } = new Dictionary<string, IMapLayer>();


        #endregion


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
                Title = "Число заболевших",
                MarkerType = MarkerType.Circle,
                StrokeThickness = 1,
                //MarkerStroke = OxyColors.Red,
                //MarkerStrokeThickness = 1,
                Color = OxyColors.GreenYellow,

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
                PushpinLocation = new Location(value.Location.X, value.Location.Y);
                OnPropertyChanged(nameof(PushpinText));
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

        public ICommand RefreshMapLocation { get; }

        private void OnRefreshMapLocationExecuted(object p)
        {
            PushpinLocation = (Location)p;
        }

        #endregion

        #region Отладочный Конструктор

        //public CountryStatisticViewModel() : this(null)
        //{
        //    if (!App.IsDesignMode)
        //        throw new InvalidOperationException("ИДИИИИИИИИИИИИИИИИИ НАХУЙЙЙЙЙЙЙЙЙ");

        //    Countries = Enumerable.Range(1, 10)
        //        .Select(i => new CountryInfo()
        //        {
        //            Name = $"Country Number {i}",
        //            Provinces = Enumerable.Range(1, 10)
        //                .Select(j => new PlaceInfo()
        //                {
        //                    Name = $"Province {j}",
        //                    Location = new PersonalPoint(i, j),
        //                    Counts = Enumerable.Range(1, 10).Select(k => new ConfirmedCount()
        //                    {
        //                        Date = DateTime.Now.Subtract(TimeSpan.FromDays(100 - k)),
        //                        Count = k
        //                    }).ToArray()
        //                }).ToArray()
        //        }).ToArray();
        //}


        #endregion
        public CountryStatisticViewModel(IDataService dataService)
        {


            #region OxyPlot

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

                #endregion


            _dataService = dataService;



            #region Commands

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
            RefreshMapLocation = new LambdaCommand(OnRefreshMapLocationExecuted);

            #endregion


            #region MapSettings


            Projections.Add(new WebMercatorProjection());
            Projections.Add(new Etrs89UtmProjection(32));

            Layers.Add(
                "OpenStreetMap WMS",
                new WmsImageLayer
                {
                    ServiceUri = new Uri("http://ows.terrestris.de/osm/service"),
                    Layers = "OSM-WMS"
                });

            Layers.Add(
                "TopPlusOpen WMS",
                new WmsImageLayer
                {
                    ServiceUri = new Uri("https://sgx.geodatenzentrum.de/wms_topplus_open"),
                    Layers = "web"
                });

            Layers.Add(
                "Orthophotos Wiesbaden",
                new WmsImageLayer
                {
                    ServiceUri = new Uri("https://geoportal.wiesbaden.de/cgi-bin/mapserv.fcgi?map=d:/openwimap/umn/map/orthophoto/orthophotos.map"),
                    Layers = "orthophoto2017"
                });

            CurrentProjection = Projections[0];
            CurrentLayer = Layers.First().Value;

            //MapBase b = (MapBase)CurrentProjection;


            #endregion

        }

    }
}
