using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using CV19Main.Infrastructure.Commands;
using CV19Main.Services.Interfaces;
using CV19Main.ViewModels.Base;
using OxyPlot;


namespace CV19Main.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IAsyncDataService _asyncData;
        public CountryStatisticViewModel CountryStatistic { get; }

        public PlotModel model;

        #region SelectedPageIndexProperty

        private int _selectedPageIndex;

        public int SelectedPageIndex
        {
            get => _selectedPageIndex;
            set { SetField(ref _selectedPageIndex, value); }
        }

        #endregion

        #region Временно не нужный хлам

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



        #endregion


        #region string DataValue - "Результат длитльной асинхронной операции"

        ///<summary> Результат длитльной асинхронной операции </summary>
        private string _DataValue;

        ///<summary> Результат длитльной асинхронной операции </summary>
        public string DataValue
        {
            get => _DataValue;
            set => SetField(ref _DataValue, value);
        }

        #endregion

        #region Commands

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            //(RootObject as Window)?.Close();

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

        #region Command StartProcessCommand - Команда которая запускает процесс

        ///<summary> Команда которая запускает процесс </summary>

        public ICommand StartProcessCommand { get; }

        ///<summary>Проверка возможности выполнения - Команда которая запускает процесс </summary>

        private static bool CanStartProcessCommandExecute(object p) => true;

        ///<summary>Логика выполнения - Команда которая запускает процесс </summary>

        private void OnStartProcessCommandExecuted(object p)
        {
           new Thread(ProcessProceed).Start();
        }

        private void ProcessProceed()
        {
            DataValue = _asyncData.GetResult(DateTime.Now);
        }

        #endregion

        #region Command StopProcessCommand - Останавливает Процесс

        ///<summary> Останавливает Процесс </summary>

        public ICommand StopProcessCommand { get; }

        ///<summary>Проверка возможности выполнения - Останавливает Процесс </summary>

        private static bool CanStopProcessCommandExecute(object p) => true;

        ///<summary>Логика выполнения - Останавливает Процесс </summary>

        private void OnStopProcessCommandExecuted(object p)
        {

        }

        #endregion


        #endregion

        public MainWindowViewModel(CountryStatisticViewModel statistic, IAsyncDataService asyncData)
        {
            _asyncData = asyncData;
            
            CountryStatistic = statistic;

            statistic.MainModel = this;
            #region Commands


            PageIndexChangeCommand =
                new LambdaCommand(OnPageIndexChangeCommandExecuted, CanPageIndexChangeCommandExecute);

            StartProcessCommand = new LambdaCommand(OnStartProcessCommandExecuted, CanStartProcessCommandExecute);

            #endregion


        }

        #region Title Property

        /// /// <summary> Заголовок окна </summary>/// <summary> Заголовок окна </summary>
        private string _title = "CV19 TIME TO ACTION";

        /// <summary> Заголовок окна </summary>
        public string Title
        {
            get { return _title; }
            set { SetField(ref _title, value); }
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