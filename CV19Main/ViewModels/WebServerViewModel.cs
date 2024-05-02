using System.Windows.Input;
using CV19Main.Infrastructure.Commands;
using CV19Main.Services.Interfaces;
using CV19Main.ViewModels.Base;

namespace CV19Main.ViewModels
{
    internal class WebServerViewModel : ViewModel
    {
        public IWebServiceServer Server { get; }

        #region Enabled

        private bool _Enabled;

        public bool Enabled
        {
            get => _Enabled;
            set => SetField(ref _Enabled, value);
        }

        #endregion

        #region Command StartCommand - summary

        ///<summary> summary </summary>

        private ICommand _StartCommand;

        public ICommand StartCommand => _StartCommand ??= new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);

        ///<summary>Проверка возможности выполнения - summary </summary>

        private bool CanStartCommandExecute(object p) => !Enabled;

        ///<summary>Логика выполнения - summary </summary>

        private void OnStartCommandExecuted(object p)
        {
            Enabled = true;
        }

        #endregion

        #region Command StopCommand - Stop


        ///<summary> Stop </summary>

        private ICommand _StopCommand;

        ///<summary> Stop </summary>

        public ICommand StopCommand => _StopCommand ??= new LambdaCommand(OnStopCommandExecuted, CanStopCommandExecute);

        ///<summary>Проверка возможности выполнения - Stop </summary>

        private bool CanStopCommandExecute(object p) => Enabled;

        ///<summary>Логика выполнения - Stop </summary>

        private void OnStopCommandExecuted(object p)
        {
            Enabled = false;
        }

        #endregion


        public WebServerViewModel(IWebServiceServer server)
        {
            Server = server;
        }

    }
}
