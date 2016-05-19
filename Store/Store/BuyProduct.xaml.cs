using System;
using System.Collections.Generic;
using System.Linq;
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
using StoreCore.BusinessLogic;
using StoreCore.Repository;

namespace Store
{
    /// <summary>
    /// Interaction logic for BuyProduct.xaml
    /// </summary>
    public partial class BuyProduct : UserControl
    {
        private Stock stock;
        private Product product;
        public BuyProduct(Product product)
        {
            this.product = product;
            InitializeComponent();
            this.stock = new Stock(product.Id, @"Repository\Product.txt", "ArrayOfProduct");
            DisableBuyButton();
           
            ProductPrice.Text = product.Price + "lei";
            ProductStock.Text = stock.GetStockMessage();
        }

        private void BuyButton_OnClick(object sender, RoutedEventArgs e)
        {
            stock.UpdateStock(int.Parse(Quantity.Text));
            var repository = new XMLRepository<ShippingCart, int>(@"Repository\ShoppingCart.txt", "ArrayOfProduct");
            repository.Add(new ShippingCart { IdProduct = product.Id.ToString(), Quantity = int.Parse(Quantity.Text) });
            MessageBox.Show("The product was added to the cart");    
            ProductStock.Text = stock.GetStockMessage();
            DisableBuyButton();
        }
       
        private void DisableBuyButton()
        {
            if (!stock.CheckStockAvailability())
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
