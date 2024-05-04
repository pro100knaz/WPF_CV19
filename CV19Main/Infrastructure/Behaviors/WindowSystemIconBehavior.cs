using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace CV19Main.Infrastructure.Behaviors
{
    class WindowSystemIconBehavior : Behavior<Image>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += OnMouseDown;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnMouseDown;

        }
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {

            var window = AssociatedObject.FindVisualRoot() as Window;
            if (window is null) return;
            e.Handled = true;

            if(e.ClickCount > 1) window.Close();

            else
            {
                // Тут должна быть функция окна как в VS  при нажатии на иконку через WinApi но я не смог
            }

        }

    }
}
