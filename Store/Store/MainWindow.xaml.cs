using System.Windows;
using StoreCore.ViewModels;

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

            DataContext = new ProductViewModel();
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            SetVisibility(Visibility.Hidden);

            var addProduct = new AddProductControl();
            ProductStackPanel.Children.Add(addProduct);
        }

        private void MenuView_Click(object sender, RoutedEventArgs e)
        {
            SetVisibility(Visibility.Visible);

            var headerControl = new HeaderControl();
            HeaderStackPanel.Children.Add(headerControl);

            var productCategoryControl = new ProductCategoryControl(ProductStackPanel);
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

            var productCategoryControl = new ProductCategoryControl(ProductStackPanel);
            CategoryListStackPanel.Children.Add(productCategoryControl);
        }
    }
    
}

