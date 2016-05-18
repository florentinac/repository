using System.Windows;
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
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            SetVisibility(Visibility.Hidden);
            var product = new Product();
            var addProduct = new AddProductControl(product, this, false);
            ProductStackPanel.Children.Add(addProduct);
        }

        private void MenuView_Click(object sender, RoutedEventArgs e)
        {
            SetVisibility(Visibility.Visible);

            var headerControl = new HeaderControl();
            HeaderStackPanel.Children.Add(headerControl);

            var productCategoryControl = new ProductCategoryControl(ProductStackPanel, false);
            CategoryListStackPanel.Children.Add(productCategoryControl);
        }

        private void SetVisibility(Visibility visibility)
        {
            ProductStackPanel.Children.Clear();
            CategoryListStackPanel.Children.Clear();
            HeaderStackPanel.Children.Clear();
            HeaderStackPanel.Visibility = visibility;
            CategoryListStackPanel.Visibility = visibility;
        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            SetVisibility(Visibility.Visible);

            var headerControl = new HeaderControl();
            HeaderStackPanel.Children.Add(headerControl);

            var productCategoryControl = new ProductCategoryControl(ProductStackPanel, true);
            CategoryListStackPanel.Children.Add(productCategoryControl);
        }
    }
    
}

