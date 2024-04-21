using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

        #region SelectedPageIndexProperty

            private int _selectedPageIndex;

            public int SelectedPageIndex
            {
                get => _selectedPageIndex;
                set
                {
                    SetField(ref _selectedPageIndex, value);
                }
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

        #region PageIndexChange

        public ICommand PageIndexChangeCommand { get; }

        private bool CanPageIndexChangeCommandExecute(object p) => SelectedPageIndex >= 0;

        private void OnPageIndexChangeCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);

        }

        #endregion 

        #region NextTabItemCommand


        #endregion

        public PlotModel model;

        #endregion

        public MainWindowViewModel()
        {

            #region Commands

            //CloseApplicationCommand =
            //    new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            PageIndexChangeCommand =
                new LambdaCommand(OnPageIndexChangeCommandExecuted, CanPageIndexChangeCommandExecute);

            #endregion

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
