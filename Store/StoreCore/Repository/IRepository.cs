using System.Collections.Generic;

namespace StoreCore.Repository
{
    public interface IRepository<T, Key> 
    {
        IEnumerable<T> GetAll();
        T GetById(Key id);
        void Add(T element);
        void Update(Key id, T element);
        void Delete(Key id);
    }
}
