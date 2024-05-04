using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CV19Main.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();

        public StudentsManagementViewModel StudentsManagementModel =>
            App.Host.Services.GetRequiredService<StudentsManagementViewModel>();
    }
}
