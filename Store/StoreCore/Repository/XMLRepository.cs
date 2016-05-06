using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace StoreCore.Repository
{
    public class XMLRepository<T, Key> : IRepository<T, Key> where T: IIndexable
    {
        private string path;
        private string fullPath;

        private XPathNavigator navigator;
        private XMLHelper xmlHelper; 


        public XMLRepository(string fullPath)
        {
            this.fullPath = fullPath;
            this.path = Path.GetDirectoryName(this.fullPath);
            //this.navigator = new XPathDocument(this.fullPath).CreateNavigator();

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

            using (var fileStream = File.OpenRead(fullPath))
            {
                using (var read = new StreamReader(fileStream))
                {
                    var serializedObject = read.ReadToEnd();
                    result = xmlHelper.Deserialize<List<T>>(serializedObject);
                }
            }  
                  
            return result;
        }

        public T GetById(Key id)
        { 
            var products = GetAll();
            foreach (var product in products)
            {
                if (product.Id.Equals(id))
                {
                    return product;
                }
            }

            return default(T);
        }        
       
        public void Add(T newItem)
        {
            if (!CheckIfFieExists())
            {
                AddFirstItem(newItem);
            }
            else
            {               
                WriteInXml(AddNewItemInList(newItem));
            }
        }

        private void AddFirstItem(T item)
        {
            var items = new List<T>();
            items.Add(item);
            WriteInXml(items);
        }

        private void WriteInXml(List<T> items)
        {
            var objectSerialize = xmlHelper.Serialize(items);

            using (var fileStream = File.Create(fullPath))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write(objectSerialize);
                }
            }
        }

        private List<T> AddNewItemInList(T newItem)
        {
            var items = GetAll().ToList();

            items.Add(newItem);

            return items;
        }

        public void Update(Key id, T element)
        {
            SaveXmlContains();
            var xPathIterator = navigator.Select("/ArrayOfProduct//Product");
            var names = new List<string>();
            foreach (XPathNavigator product in xPathIterator)
            {
                var name = product.SelectSingleNode("Name").Value;
                names.Add(name);
            }
        }

        public string SaveXmlContains()
        {
            try
            {
                var document = new XPathDocument(this.fullPath);
                this.navigator = document.CreateNavigator();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }            
        
            return navigator.OuterXml;
        }

        public void Delete(Key id)
        {
            throw new NotImplementedException();
        }

        private void InitializeDirectory()
        {
            Directory.CreateDirectory(path);
        }

        private bool CheckIfFieExists()
        {
            return File.Exists(Path.Combine(path, Path.GetFileName(this.fullPath)));
        }

    }
}
