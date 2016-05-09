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
            var repository = new XMLRepository<Product, int>(@"Repository\test.txt");
            var product1 = new Product { Category = "Food", Name = "bread", Price = 10, Stock = 2 };
            var product2 = new Product { Category = "Fruits", Name = "appel", Price = 10, Stock = 3 };
            var products = new List<Product> { new Product { Category = "Food", Id = 4, Name = "bread", Price = 10, Stock = 2 } ,
                                               new Product { Category = "Fruits", Id = 5, Name = "appel", Price = 10, Stock = 3 }};
                
            //repository.Delete(3);
            //var productRepository = new ProductRepository(@"Repository\test.txt");        
            //productRepository.UpdateStock(4);
           // repository.Add(product2);
            //var pro = repository.GetById(5);

            var productRepository = new ProductRepository(@"Repository\test.txt");
            repository.Update(3, product1);
            var result = productRepository.GetAll();
            var foodProduct = productRepository.GetByCategory("Fruits");

            ProductsList.ItemsSource = result;
            ProductsList.ItemsSource = foodProduct;




        }             
    }
}

