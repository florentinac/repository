using System.Windows.Controls;
using StoreCore.Repository;
using StoreCore.BusinessLogic;
using StoreCore.Models;
using StoreCore.ViewModels;

namespace Store
{
    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        private bool isEditable;

        public ProductControl(bool isEditable)
        {
            this.isEditable = isEditable;
                   
            InitializeComponent();
            this.DataContext = new ProductViewModel();
            this.SetComponent();
        }
        private void SetComponent()
        {                      
            if (!isEditable)
            {
                var buyProduct = new BuyProduct();
                ProductOperation.Children.Add(buyProduct);
            }
            else
            {
                var editButtons = new EditControl();
                ProductOperation.Children.Add(editButtons);
            }
        }     
    }
}
