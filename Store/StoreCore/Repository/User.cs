
namespace StoreCore.Repository
{
    public class User: IIndexable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prenume { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

    }
}
