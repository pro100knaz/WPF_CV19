using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CV19Main.Infrastructure.Commands.Base;

namespace CV19Main.Infrastructure.Commands
{
    class CloseWindowCommand : Command
    {
        public override bool CanExecute(object? parameter) => parameter is Window;
        

        public override void Execute(object? parameter)
        {
            if(!CanExecute(parameter)) return;
            var window = (Window) parameter;
            window.Close();
        }
    }

    class CloseDialogWindowCommand : Command
    {

        public bool? DialogResult { get; set; }
        public override bool CanExecute(object? parameter) => parameter is Window;

        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;
            var window = (Window)parameter;
            window.DialogResult = DialogResult;
            window.Close();
        }
    }
}
