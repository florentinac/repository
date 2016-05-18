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

        public Stock(Product product)
        {
            this.product = product;
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
        public void UpdateStock()
        {
            product.Stock = product.Stock - 1;
            repository.Update(product.Id, product);
        }

        public bool CheckStockAvailability()
        {
            return GetStockValue() != 0;
        }

        private int GetStockValue()
        {
            return product.Stock;
        }        
    }
}
