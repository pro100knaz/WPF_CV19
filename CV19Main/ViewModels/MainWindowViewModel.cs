using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CV19Main.Infrastructure.Commands;
using CV19Main.ViewModels.Base;

namespace CV19Main.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {


        #region Команды

        #region CloseApplicationCommand


        public ICommand CloseApplicationCommand { get; }

            private bool CanCloseApplicationCommandExecute(object p) => true;
            private void OnCloseApplicationCommandExecuted(object p)
            {
                Application.Current.Shutdown();
            }


        #endregion
        #endregion


        public MainWindowViewModel()
        {

            #region Commands

            CloseApplicationCommand =
                new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

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
