using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using StoreCore.Repository;

namespace Store
{
    /// <summary>
    /// Interaction logic for AddProductControl.xaml
    /// </summary>
    public partial class AddProductControl : UserControl
    {
        public AddProductControl(Product product)
        {
            InitializeComponent();
            Name.Text = product.Name;
            Category.Text = product.Category;
            Description.Text = product.Description;
            Stock.Text = product.Stock.ToString();
            Price.Text = product.Price.ToString(CultureInfo.InvariantCulture);
            Image.Text = product.Image;
        }

        private void SelectImage_OnClick(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".jpg",
                Filter =
                    "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"
            };
     
            if (dlg.ShowDialog() == true)
            {
                var filename = dlg.FileName;
                Image.Text = filename;
            };
        }

        private void SaveProduct_OnClick(object sender, RoutedEventArgs e)
        {
            var productRepository = new ProductRepository(@"Repository\Product.txt", "ArrayOfProduct");
            productRepository.Add(GetProduct());
            Name.Clear();
            Category.Clear();
            Stock.Clear();
            Price.Clear();
            Image.Clear();
            Description.Clear();

            MessageBox.Show("The product was added successfully!");

        }

        private Product GetProduct()
        {
            var product = new Product
            {
                Name = Name.Text,
                Category = Category.Text,
                Description = Description.Text,
                Stock = int.Parse(Stock.Text),
                Price = int.Parse(Price.Text),
                Image = Image.Text
            };

            return product;
        }
    }
}
