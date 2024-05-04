using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CV19Main.Infrastructure.Commands;
using CV19Main.Models.Decanat;
using CV19Main.Services.Interfaces;
using CV19Main.Services.Students;
using CV19Main.ViewModels.Base;
using CV19Main.Views.Windows;

namespace CV19Main.ViewModels
{
    internal class StudentsManagementViewModel : ViewModel
    {
        private readonly StudentsManager _studentsManager;
        private readonly IUserDialogService _userDialog;


        #region string Title - "Заголовок Окна"

        ///<summary> Заголовок Окна </summary>
        private string _Title = "Student Management";
        ///<summary> Заголовок Окна </summary>
        public string Title
        {
            get => _Title;
            set => SetField(ref _Title, value);
        }

        #endregion

        #region Group SelectedGroup - "Выбранная группа"

        ///<summary> Выбранная группа </summary>
        private Group _SelectedGroup;

        ///<summary> Выбранная группа </summary>
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => SetField(ref _SelectedGroup, value);
        }

        #endregion

        #region Student SelectedStudent - "Выбранный Студент"   

        ///<summary> Выбранный Студент </summary>
        private Student _SelectedStudent;

        ///<summary> Выбранный Студент </summary>
        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set => SetField(ref _SelectedStudent, value);
        }

        #endregion


        #region Command EditStudentCommand - Изменение информации о студенте


        ///<summary>  Изменение информации о студенте </summary>

        private ICommand _EditStudentCommand;

        ///<summary>  Изменение информации о студенте </summary>

        public ICommand EditStudentCommand => _EditStudentCommand ??=
            new LambdaCommand(OnEditStudentCommandExecuted, CanEditStudentCommandExecute);

        ///<summary>Проверка возможности выполнения -  Изменение информации о студенте </summary>

        private bool CanEditStudentCommandExecute(object p) => p is Student;

        ///<summary>Логика выполнения -  Изменение информации о студенте </summary>

        private void OnEditStudentCommandExecuted(object p)
        {
            var student = (Student)p;

            if (_userDialog.Edit(p))
            {
                _studentsManager.Update((Student)p);

                _userDialog.ShowInformation("Студент отредактирован", "Menedjer studentov");

                // OnPropertyChanged();
            }
            else
            {
                _userDialog.ShowWarnning("Отказ от редактирования", "Menedjer studentov");
            }


        }

        #endregion


        #region Command CreateNewStudentCommand - Создание нового студента


        ///<summary> Создание нового студента </summary>

        private ICommand _CreateNewStudentCommand;

        ///<summary> Создание нового студента </summary>

        public ICommand CreateNewStudentCommand => _CreateNewStudentCommand ??=
            new LambdaCommand(OnCreateNewStudentCommandExecuted, CanCreateNewStudentCommandExecute);


        ///<summary>Проверка возможности выполнения - Создание нового студента </summary>

        private bool CanCreateNewStudentCommandExecute(object p) => p is Group;

        ///<summary>Логика выполнения - Создание нового студента </summary>

        private void OnCreateNewStudentCommandExecuted(object p)
        {
            var group = (Group)p;

            var student = new Student();

            if (_userDialog.Edit(student)  && _studentsManager.Create(student, group.Name))
            {
                
               OnPropertyChanged(nameof(Students));
                return;
            }

            if (_userDialog.Confirm("Не удалось создать такого студента. Повторить?", "Менеджер Студентов"))
                OnCreateNewStudentCommandExecuted(p);
        }

        #endregion

        #region Command TestCommandCommand - Тестовая проверка


        ///<summary> Тестовая проверка </summary>

        private ICommand _TestCommandCommand;

        ///<summary> Тестовая проверка </summary>

        public ICommand TestCommandCommand => _TestCommandCommand ??
                                              new LambdaCommand(OnTestCommandCommandExecuted,
                                                  CanTestCommandCommandExecute);

        ///<summary>Проверка возможности выполнения - Тестовая проверка </summary>

        private bool CanTestCommandCommandExecute(object p) => true;

        ///<summary>Логика выполнения - Тестовая проверка </summary>

        private void OnTestCommandCommandExecuted(object p)
        {
            var value = _userDialog.GetStringValue("Введите строку", " 1231", "Значение по умолчанию");


            _userDialog.ShowInformation($"Vvedeno: {value}", "123");
        }

        #endregion


        public IEnumerable<Student> Students => _studentsManager.Students;
        public IEnumerable<Group> Groups => _studentsManager.Groups;


        public StudentsManagementViewModel(StudentsManager studentsManager, IUserDialogService UserDialog)
        {
            _studentsManager = studentsManager;
            _userDialog = UserDialog;
        }
    }
}
