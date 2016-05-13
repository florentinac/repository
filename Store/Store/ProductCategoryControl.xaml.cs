using System.Windows.Controls;
using StoreCore.Repository;

namespace Store
{
    /// <summary>
    /// Interaction logic for ProductCategoryControl.xaml
    /// </summary>
    public partial class ProductCategoryControl : UserControl
    {
        private StackPanel stackPanel;
        private ProductRepository productRepository;
        public ProductCategoryControl(StackPanel stackPanel)
        {
            this.stackPanel = stackPanel;
            InitializeComponent();

            productRepository = new ProductRepository(@"Repository\test.txt", "Product");          
            ProductsList.ItemsSource = productRepository.GetAllCategory();
        }

        private void OuterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stackPanel.Children.Clear();
            var item = ProductsList.SelectedItem;
            if (item != null)
            {                
                var products = productRepository.GetByCategory(item.ToString());
                foreach (var product in products)
                {
                    var productControl = new ProductControl(product);
                    stackPanel.Children.Add(productControl);                   
                }
            }
        }
    }
}
