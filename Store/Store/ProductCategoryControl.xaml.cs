using System.Windows.Controls;
using StoreCore.BusinessLogic;
using StoreCore.Repository;

namespace Store
{
    /// <summary>
    /// Interaction logic for ProductCategoryControl.xaml
    /// </summary>
    public partial class ProductCategoryControl : UserControl
    {
        private StackPanel stackPanel;        
        private ViewProduct viewProduct;
        private bool isEditable;

        public ProductCategoryControl(StackPanel stackPanel, bool isEditable)
        {
            this.isEditable = isEditable;
            this.stackPanel = stackPanel;
            InitializeComponent();
 
            this.viewProduct = new ViewProduct(@"Repository\Product.txt", "ArrayOfProduct");
                   
            ProductsList.ItemsSource = this.viewProduct.GetAllCategory();
        }

        private void OuterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.stackPanel.Children.Clear();
            var item = ProductsList.SelectedItem;
            if (item != null)
            {                
                var products = this.viewProduct.GetByCategory(item.ToString());
                foreach (var product in products)
                {
                    var productControl = new ProductControl(product, isEditable);
                    this.stackPanel.Children.Add(productControl);                   
                }
            }
        }
    }
}
