using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CV19Main.Models.Decanat;
using CV19Main.ViewModels;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

using CV19Main.ViewModels;

namespace CV19Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GroupsCollectionFilter(object sender, FilterEventArgs e)
        {
            if(!(e.Item is Group group )) return;
            if(group.Name is null) return;
            
            var filter_text = GroupNameFilterText.Text;

            if(filter_text.Length == 0) return;

            if(group.Name.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            if(group.Description != null && group.Description.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;

        }

        private void OnGroupsFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            var text_box = (TextBox) sender;
            var collection = (CollectionViewSource)text_box.FindResource("GroupsCollection");
            collection.View.Refresh();
        }
    }
}