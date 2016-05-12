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
using StoreCore.Repository;

namespace Store
{
    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {        
        public ProductControl(Product product)
        {
            InitializeComponent();          
            SetComponent(product);
           
        }

        private void BuyButton_OnClick(object sender, RoutedEventArgs e)
        {
            var productRepository = new ProductRepository(@"Repository\test.txt", "Product");
            productRepository.UpdateStock(2);
            MessageBox.Show("The product was added to the cart");
        }

        private void SetComponent(Product product)
        {
            var productRepository = new ProductRepository(@"Repository\test.txt", "Product");
            ProductImage.Source = productRepository.GetImageByID(product.Id);
            NameLabel.Content = product.Name;
            DescriptionLabel.Content = "This should be a product description!";
            PriceLabel.Content = product.Price + "lei";
            StockLabel.Content = "In stock";
        }
    }
}
