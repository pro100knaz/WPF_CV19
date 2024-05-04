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
using System.Windows.Shapes;

namespace CV19Main.Views.Windows
{
    
    public partial class StringValueDialogWindow : Window
    {

         public string Message {get => MEssageTextBlock.Text; set => MEssageTextBlock.Text = value;}


         public string Value
         {
             get => ValueTextBox.Text; set => ValueTextBox.Text = value;
         }
    
        public StringValueDialogWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
           if(!(e.Source is Button button)) return;

           DialogResult = !button.IsCancel;
           Close();
        }
    }
}
