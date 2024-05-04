using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19Main.Services.Interfaces
{
    interface IUserDialogService
    {
        bool Edit(object item);

        void ShowInformation(string info, string Caption);

        void ShowWarnning(string Message, string Caption);

        void ShowError(string Message, string Caption);

        bool Confirm(string Message, string Caption, bool Exclamation = false);

        string GetStringValue(string M, string C, string DefaoultValue = null);
    }
}
