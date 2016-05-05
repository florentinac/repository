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

        private XMLHelper<T> xml; 

        public XMLRepository(string fullPath)
        {
            this.fullPath = fullPath;
            this.path = Path.GetDirectoryName(this.fullPath);
            this.fileName = Path.GetFileName(this.fullPath);
            xml = new XMLHelper<T>(this.fullPath);
            InitializeDirectory();
        }
       
        public IEnumerable<T> GetAll()
        {
            var result = new List<T>();
            if (!CheckIfFieExists())
            {
                throw  new Exception("The file doesn't exists!");
            }
            result.Add(xml.DeserializeList());    

            return result;
        }

        public T GetById(key id)
        {
            throw new NotImplementedException();
        }

        public void Add(T element)
        {        
            xml.Serialize(element);          
        }

        public void AddNewEntryInXml(T entry)
        {
            xml.UpdateXmlSerialize(entry);
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
