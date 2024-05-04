using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace CV19Main.Infrastructure.Behaviors
{
    class WindowStateChanged : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += OnButtonClick;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnButtonClick;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var window = AssociatedObject.FindVisualRoot() as Window;

            if (window is null) return;

                    //switch (window.WindowState)
                    //{
                    //    case WindowState.Normal:
                    //        window.WindowState = WindowState.Maximized;
                    //        break;
                    //    case WindowState.Maximized:
                    //        window.WindowState = WindowState.Normal;
                    //        break;  
                    //}
            switch (window.WindowState)
            {
                case WindowState.Normal:
                    window.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    window.WindowState = WindowState.Normal;
                    break;
                case WindowState.Minimized:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
