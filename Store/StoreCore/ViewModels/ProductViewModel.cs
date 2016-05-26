using System.Windows.Input;
using StoreCore.BusinessLogic;
using StoreCore.Commands;
using StoreCore.Models;
using StoreCore.Repository;

namespace StoreCore.ViewModels
{
    public class ProductViewModel
    {
        private Product product;
        private IRepository<Product, int> repository; 
        public Product Product => this.product;

        public ProductViewModel()
        {
            repository = new ProductRepository(@"Repository\Product.txt", "ArrayOfProduct");

            BuyCommand = new ProductBuyCommand(new Stock(repository, Product.Id));
            SaveCommand = new ProductSaveCommand(repository, this);
            SelectCommand = new SelectImageCommand();
            DeleteCommand = new DeleteProductCommand(repository,this);
        }

        public string TxtPrice
        {
            get
            {
                return product.Price + " lei";
            }
            set
            {
                product.Price = double.Parse(value);
            }
        }

        public string TxtStock
        {
            get
            {
                if (product.Stock == 0)
                {
                    return "Unavailable stock";
                }
                return Product.Stock <= 5 ? "Few in stock" : "In stock";
            }           
        }

        public ICommand BuyCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }  
}
