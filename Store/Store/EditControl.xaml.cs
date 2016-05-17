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
using StoreCore.Repository;

namespace Store
{
    /// <summary>
    /// Interaction logic for DeleteControl.xaml
    /// </summary>
    public partial class EditControl : UserControl
    {
        private Product product;
        private IRepository<Product, int> repository; 

        public EditControl(Product product)
        {
            this.product = product;
            this.repository = new ProductRepository(@"Repository\Product.txt", "ArrayOfProduct");
            InitializeComponent();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditWindow(product);
            editWindow.Show();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var objResult = MessageBox.Show("Are You sure You want to delete?", 
                                            "Delete Confirmation", MessageBoxButton.YesNo);
            if (objResult == MessageBoxResult.Yes)
            {
                repository.Delete(product.Id);
            }

        }
    }
}
