using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StoreCore.Models;
using StoreCore.Repository;
using StoreCore.ViewModels;

namespace StoreCore.Commands
{
    class ProductSaveCommand:ICommand
    {
        private IRepository<Product, int> repository;
        private ProductViewModel productViewModel;

        public ProductSaveCommand(IRepository<Product, int> repository, ProductViewModel productViewModel)
        {
            this.productViewModel = productViewModel;
            this.repository = repository;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            repository.Add(productViewModel.Product);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
