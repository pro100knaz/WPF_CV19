using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace CV19Main.Infrastructure.Behaviors
{
    public class CloseWindowBehavior : Behavior<Button>
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
            var button = AssociatedObject;

           var window = FindWindow(button) as Window;

           window?.Close();


        }
        private static DependencyObject FindWindow(DependencyObject obj)
        {
            do
            {
                var parent = VisualTreeHelper.GetParent(obj);

                if (parent is null) return obj;
                obj = parent;

            } while (true);


        }

    }
}
