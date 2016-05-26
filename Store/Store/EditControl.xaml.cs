using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using StoreCore.Models;
using StoreCore.Repository;

namespace Store
{
    /// <summary>
    /// Interaction logic for DeleteControl.xaml
    /// </summary>
    public partial class EditControl : UserControl
    {
 
        public EditControl()
        {
            InitializeComponent();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditWindow();
            editWindow.Show();
        }       
    }
}
