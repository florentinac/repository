using System.Windows;
using System.Windows.Controls;
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

            var product1 = new Product { Category = "Food", Name = "Meat", Price = 22.33, Stock = 2, Image = @"\Repository\meat.jpg"};
            var product5 = new Product { Category = "Food", Name = "Bread", Price = 2.99, Stock = 10, Image = @"\Repository\bread.jpg" };
            var product2 = new Product { Category = "Fruits", Name = "Kiwi", Price = 9.99, Stock = 3, Image = @"\Repository\kiwi.jpg"};
            var product3 = new Product { Category = "Clothes", Name = "Dress", Price = 70, Stock = 5, Image = @"\Repository\dress.jpg" };
            var product4 = new Product { Category = "Clothes", Name = "T-shirt", Price = 24.99, Stock = 5, Image = @"\Repository\Tshirt.jpg" };
            var productRepository = new ProductRepository(@"Repository\test3.txt", "ArrayOfProduct");
            productRepository.Add(product2);
            productRepository.Add(product2);
            var products = productRepository.GetAll();
            productRepository.Delete(2);
            //productRepository.Add(product1);
            //productRepository.Add(product3);
            //productRepository.Add(product4);
            //productRepository.Add(product5);
            
            var headerControl = new HeaderControl();
            HeaderStackPanel.Children.Add(headerControl);

            var productCategoryControl = new ProductCategoryControl(ProductStackPanel);
            CategoryListStackPanel.Children.Add(productCategoryControl);                                 
        }

        private void SetStockMessage(int stock, ContentControl label)
        {
            if (stock == 0)
            {
                label.Content = "Unavailable stock";
            }
            else if (stock <= 5)
            {
                label.Content = "Few in stock";
            }
            else
            {
                label.Content = "In stock";
            }
        }
    }
    
}

