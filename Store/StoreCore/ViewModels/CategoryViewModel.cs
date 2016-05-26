using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StoreCore.Annotations;
using StoreCore.Commands;
using StoreCore.Models;
using StoreCore.Repository;

namespace StoreCore.ViewModels
{
    public class CategoryViewModel: INotifyPropertyChanged
    {
        private string category;
        private IRepository<Product, int> repository;

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
                NotifyPropertyChanged("Category");
            }
        }
       
        public CategoryViewModel()
        {
            this.repository = new ProductRepository(@"Repository\Product.txt", "ArrayOfProduct");
            SelectChangedCommand = new SelectedCategoryChangeCommand(this);
        }

        public List<string> Categoryes
        {
            get
            {
                var products = repository.GetAll();
                return products.Select(i => i.Category).Distinct().ToList();
            }
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                var products = repository.GetAll();
                return 
                    new ObservableCollection<Product>(products.Where(i=>i.Category.Equals(this.Category)));
            }
            set { NotifyPropertyChanged("Products"); } 
        }

        public ICommand SelectChangedCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
