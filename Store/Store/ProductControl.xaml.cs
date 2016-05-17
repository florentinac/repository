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
        private Stock stock;
        private Product product;

        public ProductControl(Product product)
        {
            this.product = product;   
            this.stock = new Stock(this.product.Id, @"Repository\Product.txt", "ArrayOfProduct"); 
                   
            InitializeComponent();
            DisableBuyButton();
            SetComponent();
        }

        private void BuyButton_OnClick(object sender, RoutedEventArgs e)
        {           
            stock.UpdateStock();          
            MessageBox.Show("The product was added to the cart");
            ProductStock.Text = stock.GetStockMessage();
            DisableBuyButton();
        }

        private void SetComponent()
        {
            var viewProduct = new ViewProduct(@"Repository\Product.txt", "ArrayOfProduct");           
            ProductImage.Source = viewProduct.GetImageById(this.product.Id);
            ProductName.Text = this.product.Name;
            ProductDescription.Text = this.product.Description;
            ProductPrice.Text = this.product.Price + "lei";
            ProductStock.Text = stock.GetStockMessage();
        }

        private void DisableBuyButton()
        {
            if (!stock.CheckStockAvailablity())
            {
                BuyButton.IsEnabled = false;
            }
            else
            {
                BuyButton.IsEnabled = true;
            }
        }
    }
}
