using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.ViewModels.Base;

namespace CV19Main.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title;

        /// <summary> Заголовок окна </summary>
        public string Title {
            get
            {
                return _title;
            }
            set
            {
                //if (Equals(value, _title)) return;
                //_title = value;
                
                //OnPropertyChanged();
                
                SetField(ref _title, value);
            }
        }
    }
}
