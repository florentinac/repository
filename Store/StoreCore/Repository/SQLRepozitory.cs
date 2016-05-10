using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StoreCore.Repository
{
    public class SQLRepozitory<T, Key> : IRepository<T, Key> where T : IIndexable
    {

        private SqlConnection sqlContext;       

        public SQLRepozitory(string databaseName, string serverName, string userName, string password)
        {          
            InitializeRepository(databaseName, serverName, userName, password);
        }

        public IEnumerable<T> GetAll()
        {
            var result = new List<T>();

            return result;
        }

        public T GetById(Key id)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(Key id, T element)
        {
            throw new NotImplementedException();
        }

        public void Delete(Key id)
        {
            throw new NotImplementedException();
        }

        private void InitializeRepository(string databaseName, string serverName, string userName, string password)
        {
            var database = new DBContext(databaseName, serverName, userName, password);
            this.sqlContext = database.DbConnection();
        }
    }
}
