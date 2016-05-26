using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StoreCore.Models;
using StoreCore.ViewModels;

namespace StoreCore.Commands
{
    class SelectedCategoryChangeCommand:ICommand
    {
        private CategoryViewModel categoryViewModel;

        public SelectedCategoryChangeCommand(CategoryViewModel categoryViewModel)
        {
            this.categoryViewModel = categoryViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var observableCollection = categoryViewModel.Products;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
