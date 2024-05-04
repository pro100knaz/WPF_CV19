using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Xaml.Behaviors;

namespace CV19TestWPF.Behaviors
{
    public class DragInCanvas : Behavior<UIElement>
    {
        private Point _StartPoint;

        private Canvas canva;


        #region readonly PositionX : double - Горизонтальное Смещение

        ///<summary> Горизонтальное Смещение </summary>
        public static readonly DependencyProperty PositionXProperty =
            DependencyProperty.Register(
                nameof(PositionX),
                typeof(double),
                typeof(DragInCanvas),
                new PropertyMetadata(default(double)));



        ///<summary> Горизонтальное Смещение </summary>
        //[Category("")]
        [Description("Горизонтальное Смещение")]
        public double PositionX
        {
            get { return (double)GetValue(PositionXProperty); }
            set { SetValue(PositionXProperty, value); }
        }

        #endregion

        #region readonly PositionY : double - Вертикальное положение

        ///<summary> Вертикальное положение </summary>
        public static readonly DependencyProperty PositionYProperty =
            DependencyProperty.Register(
                nameof(PositionY),
                typeof(double),
                typeof(DragInCanvas),
                new PropertyMetadata(default(double)));



        ///<summary> Вертикальное положение </summary>
        //[Category("")]
        [Description("Вертикальное положение")]
        public double PositionY
        {
            get { return (double)GetValue(PositionYProperty); }
            set { SetValue(PositionYProperty, value); }
        }

        #endregion




        protected override void OnAttached() //Поведение добавляется в коллекцию // и происходит нпример подписка или отписка от собыытий
        { 
            //ТИП ИЗ ПАРАМЕТРА ШАБЛОНА
            AssociatedObject.MouseLeftButtonDown += OnLeftButtonDown;

        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnLeftButtonDown;

            AssociatedObject.MouseMove -= OnMouseMove;
            AssociatedObject.MouseUp -= OnMouseUp;

        }

        private void OnLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           if((canva ??= VisualTreeHelper.GetParent(AssociatedObject) as Canvas) is null) return;

            _StartPoint = e.GetPosition(AssociatedObject);
            AssociatedObject.CaptureMouse();
            AssociatedObject.MouseMove += OnMouseMove;
            AssociatedObject.MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            AssociatedObject.MouseMove -= OnMouseMove;
            AssociatedObject.MouseUp -= OnMouseUp;
            AssociatedObject.ReleaseMouseCapture();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {

            var obj = AssociatedObject;
            var current_pos = e.GetPosition(canva);

            var delta = current_pos - _StartPoint;

            obj.SetValue(Canvas.LeftProperty, delta.X);
            obj.SetValue(Canvas.TopProperty, delta.Y);

            PositionX = delta.X; PositionY = delta.Y;

        }
    }
}
