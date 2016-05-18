using System.Windows;
using System.Windows.Controls;
using StoreCore.Repository;
using StoreCore.BusinessLogic;

namespace Store
{
    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        private Product product;
        private bool isEditable;

        public ProductControl(Product product, bool isEditable)
        {
            this.isEditable = isEditable;
            this.product = product;   
                   
            InitializeComponent();
            SetComponent();
        }
        private void SetComponent()
        {
            var viewProduct = new ViewProduct(@"Repository\Product.txt", "ArrayOfProduct");           
            ProductImage.Source = viewProduct.GetImageById(this.product.Id);
            ProductName.Text = this.product.Name;
            ProductDescription.Text = this.product.Description;

            if (!isEditable)
            {
                var buyProduct = new BuyProduct(product);
                ProductOperation.Children.Add(buyProduct);
            }
            else
            {
                var editButtons = new EditControl(product);
                ProductOperation.Children.Add(editButtons);
            }
        }     
    }
}
