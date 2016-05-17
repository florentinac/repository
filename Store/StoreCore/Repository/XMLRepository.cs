using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace StoreCore.Repository
{
    public class XMLRepository<T, Key> : IRepository<T, Key> where T: IIndexable
    {
        private string path;        
        private string tabelName;
        private XMLHelper xmlHelper;
        protected string fullPath;
        protected XDocument doc;

        public XMLRepository(string fullPath, string tabelName)
        {         
            this.fullPath = fullPath;
            this.path = Path.GetDirectoryName(this.fullPath);
            this.tabelName = tabelName;

            this.InitializationXDocument();
            this.xmlHelper = new XMLHelper();
            InitializeDirectory();
        }

        
        public IEnumerable<T> GetAll()
        {
            if (!CheckIfFieExists())
            {
                throw  new Exception("The file doesn't exists!");
            }

            var result = new List<T>();

            using (var fileStream = File.OpenRead(this.fullPath))
            {
                using (var read = new StreamReader(fileStream))
                {
                    var serializedObject = read.ReadToEnd();
                    result = this.xmlHelper.Deserialize<List<T>>(serializedObject);
                }
            }  
                  
            return result;
        }

        public T GetById(Key id)
        { 
            var products = this.GetAll();
            foreach (var product in products)
            {
                if (product.Id.Equals(id))
                {
                    return product;
                }
            }

            return default(T);
        }        
       
        public void Add(T item)
        {                       
            var count = doc.Root.Elements().Count();
            item.Id = count + 1;

            var objectSerialized = this.xmlHelper.Serialize(item);
            var itemNode = XElement.Parse(objectSerialized);
            var newNode = new XElement(itemNode);

            doc.Element(this.tabelName).Add(newNode);
            doc.Save(this.fullPath);
        }             

        public virtual void Update(Key id, T element)
        {          
        }      

        public virtual void Delete(Key id)
        {            
        }
       
        private void InitializationXDocument()
        {
            if (!CheckIfFieExists())
            {
                doc = new XDocument(new XElement(tabelName));
            }
            else
            {
                doc = XDocument.Load(this.fullPath);
            }
        }

        private void InitializeDirectory()
        {
            Directory.CreateDirectory(this.path);
        }

        private bool CheckIfFieExists()
        {
            return File.Exists(Path.Combine(this.path, Path.GetFileName(this.fullPath)));
        }

    }
}
