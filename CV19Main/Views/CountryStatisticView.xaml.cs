using CV19Main.ViewModels;
using CV19Main.ViewModels.Base;
using MapControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CV19Main.Views
{
    /// <summary>
    /// Логика взаимодействия для CountryStatisticView.xaml
    /// </summary>
    public partial class CountryStatisticView : UserControl
    {
        public CountryStatisticView()
        {
            InitializeComponent();
        }



        private void Map_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var map = (MapBase)sender;
            var pos = e.GetPosition(map);
            
        }


        //private void Map_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    var map = (MapBase)sender;
        //    var pos = e.GetPosition(map);


        //    PushpinLocation = map.ViewToLocation(pos);
        //}
    }
}
