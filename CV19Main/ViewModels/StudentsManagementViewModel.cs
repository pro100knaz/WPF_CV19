using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.ViewModels.Base;

namespace CV19Main.ViewModels
{
    internal class StudentsManagementViewModel : ViewModel
    {


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

        public StudentsManagementViewModel()
        {
            

        }
    }
}
