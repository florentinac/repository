using System;
using System.Windows.Input;
using StoreCore.Models;
using StoreCore.Repository;
using StoreCore.ViewModels;

namespace StoreCore.Commands
{
    class DeleteProductCommand:ICommand
    {
        private IRepository<Product, int> repository;
        private ProductViewModel productViewModel; 

        public DeleteProductCommand(IRepository<Product, int> repository, ProductViewModel productViewModel)
        {
            this.repository = repository;
            this.productViewModel = productViewModel;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {    
           repository.Delete(productViewModel.Product.Id);           
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
