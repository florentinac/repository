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
        protected string fullPath;

        private XPathNavigator navigator;
        private XMLHelper xmlHelper;
        protected XmlDocument document;


        public XMLRepository(string fullPath)
        {
            this.fullPath = fullPath;
            this.path = Path.GetDirectoryName(this.fullPath);

            this.document = new XmlDocument();
            this.document.Load(this.fullPath);

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
       
        public void Add(T newItem)
        {
            if (!CheckIfFieExists())
            {
                this.AddFirstItem(newItem);
            }
            else
            {               
                this.WriteInXml(this.AddNewItemInList(newItem));
            }
        }

        private void AddFirstItem(T item)
        {
            var items = new List<T>();
            item.Id = items.Count + 1;
            items.Add(item);
            this.WriteInXml(items);
        }     

        private void WriteInXml(List<T> items)
        {
            var objectSerialize = this.xmlHelper.Serialize(items);

            using (var fileStream = File.Create(this.fullPath))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write(objectSerialize);
                }
            }
        }

        private List<T> AddNewItemInList(T newItem)
        {
            var items = this.GetAll().ToList();

            newItem.Id = items.Count + 1;
            items.Add(newItem);

            return items;
        }

        public virtual void Update(Key id, T element)
        {                   
            var serialize = xmlHelper.Serialize(element);

            XmlNode xnode = document.CreateNode(XmlNodeType.Element,"Product", null);

            xnode.InnerXml = serialize;
            document.DocumentElement.AppendChild(xnode);

            document.Save(this.fullPath);
            //Console.WriteLine(navigator.OuterXml);
        }

        public string SaveXmlContains()
        {
            try
            {             
                this.navigator = this.document.CreateNavigator();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }            
        
            return this.navigator.OuterXml;
        }

        public void Delete(Key id)
        {
            var nodeToDelete = this.document.SelectSingleNode("/ArrayOfProduct/Product[@ID='" + id + "']");
            if (nodeToDelete != null)
            {
                nodeToDelete.ParentNode.RemoveChild(nodeToDelete);               
                this.document.Save(this.fullPath);
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
