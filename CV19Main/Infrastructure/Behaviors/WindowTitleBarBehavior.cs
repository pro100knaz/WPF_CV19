using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace CV19Main.Infrastructure.Behaviors
{
    class WindowTitleBarBehavior : Behavior<UIElement>
    {
        private Window _Window;


        protected override void OnAttached()
        {
            _Window = AssociatedObject as Window ?? AssociatedObject.FindLogicalParent<Window>();
            AssociatedObject.MouseLeftButtonDown += OnMouseDown;

        }


        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnMouseDown;
            _Window = null;
        }
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (e.ClickCount )
            {
                case 1:
                    DragMove(); break;
                case 2:
                    MaximizeMinimize();
                    break;
            }

           
        }

        private void DragMove()
        {
            var window = AssociatedObject.FindVisualRoot() as Window;

            if (window is null) return;

            window.DragMove();
        }

        private void MaximizeMinimize()
        {
            var window = AssociatedObject.FindVisualRoot() as Window;

            if (window is null) return;

            switch (window.WindowState)
            {
                case WindowState.Normal:
                    window.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    window.WindowState = WindowState.Normal;
                    break;
            }

        }

    }
}
