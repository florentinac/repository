using System.Data.Entity;
using StoreCore.Models;

namespace StoreCore.Repository
{
    public class StoreDBContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tranzaction> Tranzactions { get; set; }

    }
}
