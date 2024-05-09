using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CV19Main.ViewModels;
using MapControl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xaml.Behaviors;

namespace CV19Main.Infrastructure.Behaviors
{
    internal class MapBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseRightButtonUp += OnMouseUp;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseRightButtonUp -= OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var map = (MapBase)sender;
            var pos = e.GetPosition(map);
            ((CountryStatisticViewModel)(App.Host.Services.GetRequiredService(typeof(CountryStatisticViewModel)))).PushpinLocation = map.ViewToLocation(pos);

           //Создать Сервис Для Локации
           //Подключить его к CountryStatisticViewModel
           //
        }
    }
}
