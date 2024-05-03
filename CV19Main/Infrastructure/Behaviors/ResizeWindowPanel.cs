using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using Microsoft.Xaml.Behaviors;

namespace CV19Main.Infrastructure.Behaviors
{
    class ResizeWindowPanel : Behavior<Panel>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseDown += OnMouseDown;
        }


        protected override void OnChanged()
        {
            AssociatedObject.MouseDown -= OnMouseDown;
        }
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var window = AssociatedObject.FindVisualRoot() as Window;

            if (window is null) return;

            switch (e.OriginalSource )
            {
                default:return;
                case Line line:
                    ResizeLine(line,window);
                    break; 
                case Rectangle rect:
                    ResizeRect(rect,window);
                    break;


            }

        }

        private void ResizeLine(Line line , Window window)
        {
            switch (line.VerticalAlignment)
            {
                case VerticalAlignment.Top:

                    break;

                case VerticalAlignment.Bottom:
                    break;

                default:
                    switch (line.HorizontalAlignment)
                    {
                        case HorizontalAlignment.Left:
                            break;
                        case HorizontalAlignment.Right:
                            break;
                    }
                    break;
            }
        } 
        private void ResizeRect(Rectangle rect, Window window)
        {

        }
    }
}
