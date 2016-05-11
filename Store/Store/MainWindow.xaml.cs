using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using StoreCore.Repository;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var product1 = new Product { Category = "Food", Name = "bread", Price = 10, Stock = 2, Image = @"\Repository\bread.jpg"};
            var product2 = new Product { Category = "Fruits", Name = "appel", Price = 10, Stock = 3, Image = @"\Repository\appel.jpg"};            

            var productRepository = new ProductRepository(@"Repository\test.txt", "Product");
            productRepository.Add(product2);
            productRepository.Add(product1);
            productRepository.Delete(5);
            var result = productRepository.GetAllCategory();

            ProductsList.ItemsSource = result;                                   
        }

        private void OuterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            var item = ProductsList.SelectedItem;
            if (item != null)
            {
                var productRepository = new ProductRepository(@"Repository\test.txt", "Product");
                var products = productRepository.GetByCategory(item.ToString());
                ProductImage.Source = productRepository.GetImageByID(4); 
                                             
            }
            var product1 = new Product { Category = "Food", Name = "bread", Price = 10, Stock = 2, Image = @"\Repository\bread.jpg" };
            NameLabel.Content = product1.Name;
            DescriptionLabel.Content = "This is a good bread";
            PriceLabel.Content = product1.Price + " lei";
            SetStockMessage(product1);
        }

        private void SetStockMessage(Product product1)
        {
            if (product1.Stock == 0)
            {
                StockLabel.Content = "Unavailable stock";
            }
            else if (product1.Stock <= 5)
            {
                StockLabel.Content = "Few in stock";
            }
            else
            {
                StockLabel.Content = "In stock";
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var productRepository = new ProductRepository(@"Repository\test.txt", "Product");
            productRepository.UpdateStock(6);
            MessageBox.Show("The product was added to the cart");
        }
    }
}

