using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using CV19Main.Infrastructure.Commands;
using CV19Main.Models;
using CV19Main.Models.Decanat;
using CV19Main.Services.Interfaces;
using CV19Main.ViewModels.Base;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Wpf;


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

        #region Students And Group




        public ObservableCollection<Group> Groups { get; set; }

        private Group _SelectedGroup;
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set
            {
                if (!SetField(ref _SelectedGroup, value)) return;
                _SelectedGroupStudents.Source = value?.Students;
                OnPropertyChanged(nameof(SelectedGroupStudents));
            }
        }

        private void OnStedentFiltered(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Student student))
            {
                e.Accepted = false;
                return;
            }

            var filter_text = _StudentFilterText;
            if (string.IsNullOrWhiteSpace(filter_text))
            {
                return;
            }

            if (student.Name is null || student.SureName is null)
            {
                e.Accepted = false;
                return;
            }
            if (student.Name.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            if (student.SureName.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;


        }

        private readonly CollectionViewSource _SelectedGroupStudents = new CollectionViewSource();
        public ICollectionView SelectedGroupStudents => _SelectedGroupStudents?.View;

        #endregion

        #region StudentFilterText

        private string _StudentFilterText;

        public string StudentFilterText
        {
            get => _StudentFilterText;
            set
            {
                if (!SetField(ref _StudentFilterText, value)) return;

                _SelectedGroupStudents.View.Refresh();

            }
        }

        #endregion


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





        public DirectoryViewModel DiskRootDir { get; } = new DirectoryViewModel("c:\\");

        #region SelectedDirectiory

        private DirectoryViewModel _SelectedDirectiory;

        public DirectoryViewModel SelectedDirectiory
        {
            get => _SelectedDirectiory;
            set => SetField(ref _SelectedDirectiory, value);
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



        #region CreateNewGroupCommand

        public ICommand CreateNewGroupCommand { get; }

        private bool CanCreateNewGruopCommandExecute(object p) => true;

        public void OnCreateNewGruopCommandExecuted(object p)
        {
            var group_max_index = Groups.Count + 1;
            var new_group = new Group()
            {
                Name = $"GROUP {group_max_index}",
                Students = new ObservableCollection<Student>()
            };
            Groups.Add(new_group);
        }

        #endregion


        #region  DeleteGroupCpmmand Command

        public ICommand DeleteGroupCpmmand { get; }

        private bool CanDeleteGroupCpmmandExecute(object p) => p is Group group && Groups.Contains(group);

        public void OnDeleteGroupCpmmandExecuted(object p)
        {
            if (!(p is Group group)) return;

            int group_index = Groups.IndexOf(group);
            Groups.Remove(group);

            if (group_index < Groups.Count)
            {
                SelectedGroup = Groups[group_index];
            }

        }

        #endregion

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

            //CloseApplicationCommand =
            //    new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            CreateNewGroupCommand = new LambdaCommand(OnCreateNewGruopCommandExecuted, CanCreateNewGruopCommandExecute);

            DeleteGroupCpmmand = new LambdaCommand(OnDeleteGroupCpmmandExecuted, CanDeleteGroupCpmmandExecute);

            PageIndexChangeCommand =
                new LambdaCommand(OnPageIndexChangeCommandExecuted, CanPageIndexChangeCommandExecute);

            StartProcessCommand = new LambdaCommand(OnStartProcessCommandExecuted, CanStartProcessCommandExecute);

            #endregion

            #region StudentsCreation




            var student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student()
            {
                Name = $"Name {student_index}",
                SureName = $"Surname {student_index++}",
                Birthday = DateTime.Now,
                Rating = 0
            });

            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });

            Groups = new ObservableCollection<Group>(groups);

            _SelectedGroupStudents.Filter += OnStedentFiltered;

            // _SelectedGroupStudents.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
            // _SelectedGroupStudents.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
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