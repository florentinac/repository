using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace StoreCore.Repository
{
    public class XMLRepository<T, Key> : IRepository<T, Key> where T: IIndexable
    {
        private string path;
        protected string fullPath;
        private string tabelName;
        private XMLHelper xmlHelper;
        protected XmlDocument document;

        public XMLRepository(string fullPath, string tabelName)
        {         
            this.fullPath = fullPath;
            this.path = Path.GetDirectoryName(this.fullPath);
            this.tabelName = tabelName;

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
       
        public void Add(T item)
        {
            if (!CheckIfFieExists())
            {
                this.AddFirstItem(item);
            }
            else
            {               
                this.AddNewItem(item);
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

        private void AddNewItem(T item)
        {
            item.Id = document.SelectNodes("/ArrayOf" + tabelName + "/" + tabelName).Count + 1;
            var serializedElement = xmlHelper.Serialize(item);

            var newNode = document.CreateNode(XmlNodeType.Element, "ArrafyOf"+tabelName, null);
            newNode.InnerXml = serializedElement;

            var node = newNode.SelectSingleNode(tabelName);
            document.DocumentElement.AppendChild(node);

            document.Save(this.fullPath);
        }

        public virtual void Update(Key id, T element)
        {          
        }      

        public void Delete(Key id)
        {
            var nodeToDelete =
                this.document.SelectSingleNode("/ArrayOf" + tabelName + "/" + tabelName + "[@ID='" + id + "']");
            UpdateIDNodes(id);
            if (nodeToDelete != null)
            {
                nodeToDelete.ParentNode.RemoveChild(nodeToDelete);               
                this.document.Save(this.fullPath);
            }
        }

        private void UpdateIDNodes(Key id)
        {
            var nodetoUpdateId =
                this.document.SelectNodes("/ArrayOf" + tabelName + " / " + tabelName + "[@ID > '" + id + "']");
            foreach (XmlNode node in nodetoUpdateId)
            {
                node.Attributes["ID"].Value = (int.Parse(node.Attributes["ID"].Value) - 1).ToString();
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
