using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace System.Windows
{
    static class DependencyObjectExtensions
    {
        public static DependencyObject FindVisualRoot(this DependencyObject obj)
        {
            do
            {
                var parent = VisualTreeHelper.GetParent(obj);

                if (parent is null) return obj;
                obj = parent;

            } while (true);
        }
        public static DependencyObject FindLogicalRoot(this DependencyObject obj)
        {
            do
            {
                var parent = LogicalTreeHelper.GetParent(obj);

                if (parent is null) return obj;
                obj = parent;

            } while (true);
        }

    }
}
