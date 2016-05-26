using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using StoreCore.BusinessLogic;
using StoreCore.ViewModels;

namespace StoreCore.Commands
{
    public class ProductBuyCommand : ICommand
    {
        private Stock stock;

        public ProductBuyCommand(Stock stock)
        {
            this.stock = stock;
        }

        public bool CanExecute(object parameter)
        {
            return stock.CheckStockAvailability();
        }

        public void Execute(object parameter)
        {
            stock.UpdateStock(1);
            MessageBox.Show("The product was added to the cart");
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
