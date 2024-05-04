using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CV19Main.Infrastructure.Commands.Base;
using CV19Main.Views.Windows;

namespace CV19Main.Infrastructure.Commands
{
    class ManageStudentsCommand : Command
    {

        private StudentsManagmentWindow _Window;

        public override bool CanExecute(object? parameter) => _Window == null;

        public override void Execute(object? parameter)
        {
            var window = new StudentsManagmentWindow()
            {
                Owner = Application.Current.MainWindow
            };
            _Window = window;

            window.Closed += OnWindowClosed;
            window.ShowDialog();
        }

        private void OnWindowClosed(object? sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            _Window = null;
        }
    }
}
