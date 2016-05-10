using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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
using StoreCore;
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
            var result = productRepository.GetAll();
            var foodProduct = productRepository.GetByCategory("Fruits");

            ProductsList.ItemsSource = result;
            ProductsList.ItemsSource = foodProduct;

           // ProductImage.Source =productRepository.GetImageByID(3);
                
        }

        private void ListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var productRepository = new ProductRepository(@"Repository\test.txt", "Product");
            ProductImage.Source = productRepository.GetImageByID(3);
        }
    }
}

