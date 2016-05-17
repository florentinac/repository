using StoreCore.Repository;

namespace StoreCore.BusinessLogic
{
    public class Stock
    {
        private IRepository<Product, int> repository;
        private Product product;

        public Stock(int id,string path, string tabelName)
        {          
            this.repository = new ProductRepository(path, tabelName);
            this.product = repository.GetById(id);
        }

        public string GetStockMessage()
        {
            var stock = this.GetStockValue();

            if (stock == 0)
            {
                return "Unavailable stock";
            }

            return stock <= 5 ? "Few in stock" : "In stock";
        }

        private int GetStockValue()
        {
            return product.Stock;
        }

        public void UpdateStock()
        { 
            product.Stock = product.Stock - 1;
            repository.Update(product.Id, product);
        }

        public bool CheckStockAvailablity()
        {
            return GetStockValue() != 0;
        }
    }
}
