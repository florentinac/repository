using System.Windows;
using System.Windows.Controls;
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
            ProductName.Text = product.Name;
            ProductDescription.Text= "This should be a product description!";
            ProductPrice.Text = product.Price + "lei";
            ProductStock.Text = "In stock";
        }
    }
}
