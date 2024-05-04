using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<Student> Students => _studentsManager.Students;
        public IEnumerable<Group> Groups => _studentsManager.Groups;


        public StudentsManagementViewModel(StudentsManager studentsManager)
        {
            _studentsManager = studentsManager;
        }
    }
}
