using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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

            var product1 = new Product { Category = "Food", Name = "bread", Price = 10, Stock = 2, Image = @"\Repository\bread.jpg"};
            var product2 = new Product { Category = "Fruits", Name = "appel", Price = 10, Stock = 3, Image = @"\Repository\appel.jpg"};            

            var productRepository = new ProductRepository(@"Repository\test.txt", "Product");
            productRepository.Add(product2);
            productRepository.Add(product1);
            productRepository.Delete(5);
            var result = productRepository.GetAllCategory();

            ProductsList.ItemsSource = result;                                   
        }

        private void OuterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            StackPanel.Children.Clear();
            var item = ProductsList.SelectedItem;
            if (item != null)
            {
                var productRepository = new ProductRepository(@"Repository\test.txt", "Product");
                var products = productRepository.GetByCategory(item.ToString());
                foreach (var product in products)
                {
                    var grid = CreateGridDinamicaly(StackPanel);
                    CreateButton("Buy Product","BuyProduct",grid);
                    AddImage(productRepository.GetImageByID(product.Id), grid);
                    CreateLabelNameDynamically(grid,product.Name);
                    CreateLabelDescriptionDynamically(grid,"This should be a product description!");
                }                                                           
            }
        }

        private void SetStockMessage(int stock, Label label)
        {
            if (stock == 0)
            {
                label.Content = "Unavailable stock";
            }
            else if (stock <= 5)
            {
                label.Content = "Few in stock";
            }
            else
            {
                label.Content = "In stock";
            }
        }
        private Grid CreateGridDinamicaly(StackPanel stackPanel)
        {
            var grid = new Grid();

            var gridCol1 = new ColumnDefinition();            
            var gridCol2 = new ColumnDefinition();
            var gridCol3 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(gridCol1);
            grid.ColumnDefinitions.Add(gridCol2);
            grid.ColumnDefinitions.Add(gridCol3);

            var gridRow1 = new RowDefinition();         
            grid.RowDefinitions.Add(gridRow1);
           
            stackPanel.Children.Add(grid);

            return grid;
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var productRepository = new ProductRepository(@"Repository\test.txt", "Product");
            productRepository.UpdateStock(6);
            MessageBox.Show("The product was added to the cart");
        }

        private void CreateButton(string content, string name, Grid grid)
        {
            var newButton = new Button
            {
                Content = content,
                Name = name
            };

            newButton.Click += (BuyButton_Click);
            newButton.Width = 100;
            newButton.Height = 30;   
            Grid.SetColumn(newButton,2);
            Grid.SetRow(newButton,0);     
            grid.Children.Add(newButton);
        }

        private void AddImage(BitmapImage image, Grid grid)
        {
            var i = new Image
            {
                Source = image,
                Stretch = Stretch.Uniform,
                Height = 80,
                Width = 80
            };

            Grid.SetColumn(i,0);
            Grid.SetRow(i,0);
            grid.Children.Add(i);
        }

        private void CreateLabelNameDynamically(Grid grid, string name)
        {
            var dynamicLabel = new Label
            {
                Name = name,
                Width = 240,
                Height = 50,
                Foreground = new SolidColorBrush(Colors.Black),
                Content = name,
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };

            Grid.SetColumn(dynamicLabel,1);
            Grid.SetRow(dynamicLabel,0);
            grid.Children.Add(dynamicLabel);
        }

        private void CreateLabelDescriptionDynamically(Grid grid, string content)
        {
            var dynamicLabel = new Label
            {
                Name = "DescriptionLabel",
                Width = 240,
                Height = 50,
                Foreground = new SolidColorBrush(Colors.Black),
                Content = Environment.NewLine + content,
                FontSize = 14,                            
            };

            Grid.SetColumn(dynamicLabel, 1);
            Grid.SetRow(dynamicLabel, 0);
            TextBlock txtBlock = new TextBlock();
            txtBlock.TextWrapping = TextWrapping.Wrap;
            dynamicLabel.Content = txtBlock;
            grid.Children.Add(dynamicLabel);
            
        }
    }
    
}

