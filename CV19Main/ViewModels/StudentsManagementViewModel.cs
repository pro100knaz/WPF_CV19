using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CV19Main.Infrastructure.Commands;
using CV19Main.Models.Decanat;
using CV19Main.Services.Students;
using CV19Main.ViewModels.Base;

namespace CV19Main.ViewModels
{
    internal class StudentsManagementViewModel : ViewModel
    {
        private readonly StudentsManager _studentsManager;


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

        }

        #endregion


        #region Command CreateNewStudentCommand - Создание нового студента


        ///<summary> Создание нового студента </summary>

        private ICommand _CreateNewStudentCommand;

        ///<summary> Создание нового студента </summary>

        public ICommand CreateNewStudentCommand
        {
            get => _CreateNewStudentCommand;
        }

        ///<summary>Проверка возможности выполнения - Создание нового студента </summary>

        private bool CanCreateNewStudentCommandExecute(object p) => p is Group;

        ///<summary>Логика выполнения - Создание нового студента </summary>

        private void OnCreateNewStudentCommandExecuted(object p)
        {
            var group = (Group) p;


        }

        #endregion


        public IEnumerable<Student> Students => _studentsManager.Students;
        public IEnumerable<Group> Groups => _studentsManager.Groups;


        public StudentsManagementViewModel(StudentsManager studentsManager)
        {
            _studentsManager = studentsManager;
        }
    }
}
