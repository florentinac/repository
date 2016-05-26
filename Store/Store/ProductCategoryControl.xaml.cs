using System.Windows.Controls;
using StoreCore.ViewModels;

namespace Store
{
    /// <summary>
    /// Interaction logic for ProductCategoryControl.xaml
    /// </summary>
    public partial class ProductCategoryControl : UserControl
    {
        public ProductCategoryControl(StackPanel stackPanel)
        {
            InitializeComponent();

            DataContext = new CategoryViewModel();

            var product = new ProductControl(true);
            stackPanel.Children.Add(product);
        }    
    }
}
