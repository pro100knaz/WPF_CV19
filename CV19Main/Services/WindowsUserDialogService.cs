using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CV19Main.Models.Decanat;
using CV19Main.Services.Interfaces;
using CV19Main.Views.Windows;

namespace CV19Main.Services
{
    class WindowsUserDialogService : IUserDialogService
    {
        private static Window ActiveWindow =>
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            switch (item)
            {
                case Student student:
                    return EditStudent(student);
                default: throw new NotSupportedException($"Редактирование обЬекта типа {item.GetType().Name} НЕ ПОДДЕРЖИВАЕТСЯ");
            }
        }

        public void ShowInformation(string info, string Caption)
        {
            MessageBox.Show(
                info,
                Caption,
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowWarnning(string Message, string Caption)
        {
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ShowError(string Message, string Caption)
        {
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool Confirm(string Message, string Caption, bool Exclamation = false)
        {
            return MessageBox.Show(
                Message, 
                Caption, 
                MessageBoxButton.YesNo,
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question) 
                   == MessageBoxResult.Yes;
        }

        public string GetStringValue(string M, string C, string DefaoultValue = null)
        {
            var value_dialog = new StringValueDialogWindow()
            {
                Message = M,
                Title = C,
                Value = DefaoultValue ?? string.Empty,
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            return value_dialog.ShowDialog() == true ? value_dialog.Value : DefaoultValue;
        }

        private static bool EditStudent(Student student)
        {
            var dlg = new StudentEditorWindow()
            {
                StudentName = student.Name,
                SecondName = student.SureName,
                Birthaday = student.Birthday,
                Rating = student.Rating,
                Owner = Application.Current.Windows.OfType<StudentsManagmentWindow>().FirstOrDefault(),
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            student.Name = dlg.StudentName;
            student.SureName = dlg.SecondName;
                student.Rating = dlg.Rating;
                student.Birthday = dlg.Birthaday;
                
            return true;
        }
    }
}
