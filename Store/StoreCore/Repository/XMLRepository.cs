using System;
using System.Collections.Generic;
using System.IO;

namespace StoreCore.Repository
{
    public class XMLRepository<T, key> : IRepository<T, key>
    {
        private string path;
        private string fileName;
        private string fullPath;

        public XMLRepository(string fullPath)
        {
            this.fullPath = fullPath;
            this.path = Path.GetDirectoryName(this.fullPath);
            this.fileName = Path.GetFileName(this.fullPath);
            InitializeDirectory();
        }
       
        public IEnumerable<T> GetAll()
        {
            var result = new List<T>();
            if (!CheckIfFieExists())
            {
                throw  new Exception("The file doesn't exists!");
            }
            var xml = new XMLHelper<T>(fullPath);
            xml.DeserializeList();    

            return result;
        }

        public T GetById(key id)
        {
            throw new NotImplementedException();
        }

        public void Add(T element)
        {
            var xml = new XMLHelper<T>(fullPath);
            xml.Serialize(element);
        }

        public void Update(key id, T element)
        {
            throw new NotImplementedException();
        }

        public void Delete(key id)
        {
            throw new NotImplementedException();
        }

        private void InitializeDirectory()
        {
            Directory.CreateDirectory(path);
        }

        private bool CheckIfFieExists()
        {
            return File.Exists(Path.Combine(path, fileName));
        }

    }
}
