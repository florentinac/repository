using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using StoreCore.Annotations;
using StoreCore.Repository;

namespace StoreCore.Models
{
    [XmlRoot("Product")]
    public class Product: IIndexable, INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string description;
        private string category;
        private double price;
        private int stock;
        private string image;

        public event PropertyChangedEventHandler PropertyChanged;

        [XmlAttribute("ID")]
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.NotifyPropertyChanged("Id");
            } 
        }

        [XmlElement("Name")]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.NotifyPropertyChanged("Name");
            } 
        }

        [XmlElement("Description")]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                this.NotifyPropertyChanged("Description");
            }
        }

        [XmlElement("Price")]
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
                this.NotifyPropertyChanged("Price");
            }
        }

        [XmlElement("Category")]
        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
                this.NotifyPropertyChanged("Category");
            }
        }

        [XmlElement("Stock")]
        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                this.stock = value;
                this.NotifyPropertyChanged("Stock");
            }
        }

        [XmlElement("Image")]
        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
                this.NotifyPropertyChanged("Image");
            }
        }

        public string StockStatus
        {
            get
            {
                if (this.stock == 0)
                {
                    return "Unavailable stock";
                }
                return this.stock <= 5 ? "Few in stock" : "In stock";
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
