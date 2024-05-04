using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Infrastructure.Commands.Base;

namespace CV19Main.Infrastructure.Commands
{
    //RelayCommand - в оригинале
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
                _CanExecute = CanExecute;
                _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
        }

        public override bool CanExecute(object? parameter)
        {
            return _CanExecute?.Invoke(parameter) ?? true;
        }
        public override void Execute(object? parameter)
        {
            if(!CanExecute(parameter)) return;
            _Execute(parameter);
        }
    }
}
