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

        private string _description;
        public string Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }
    }
}
