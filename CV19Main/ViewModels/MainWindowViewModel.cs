using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CV19Main.Infrastructure.Commands;
using CV19Main.Models;
using CV19Main.ViewModels.Base;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Wpf;

namespace CV19Main.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region TestDataPoints

        private IEnumerable<DataPoint> _testDataPoints;
        /// <summary>
        /// Тестовый набор данных для визуализации графиков
        /// </summary>
        public IEnumerable<DataPoint> TestDataPoints
        {
            get => _testDataPoints;
            set => SetField(ref _testDataPoints, value);
        }

        #endregion

        #region Commands 

        #region CloseApplicationCommand   


        public ICommand CloseApplicationCommand { get; }

            private bool CanCloseApplicationCommandExecute(object p) => true;
            private void OnCloseApplicationCommandExecuted(object p)
            {
                Application.Current.Shutdown();
            }


        #endregion

        #region ShowAxes


        #endregion

        public PlotModel model;

        #endregion

        #region Points and oxes



        #endregion

        public MainWindowViewModel()
        {

            #region Commands

            //CloseApplicationCommand =
            //    new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int) (360/0.1));

            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);
                data_points.Add(new DataPoint(x,y));
            }

            TestDataPoints = data_points;
        }


        #region Title Property

        
            /// /// <summary> Заголовок окна </summary>/// <summary> Заголовок окна </summary>
            private string _title = "CV19 TIME TO ACTION";

            /// <summary> Заголовок окна </summary>
            public string Title {
                get
                {
                    return _title;
                }
                set
                {
                    
                    SetField(ref _title, value);
                }
            }

        #endregion

        #region Status Property

            private string _status = "Ready";

            /// <summary>
        /// Поле описывающее состояние программмы
        /// </summary>
            public string Status
            {
                get => _status;
                set => SetField(ref _status, value);
            }

        #endregion

       
    }
}
