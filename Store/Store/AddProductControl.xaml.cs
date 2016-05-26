using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using StoreCore.Models;
using StoreCore.Repository;
using StoreCore.ViewModels;

namespace Store
{
    /// <summary>
    /// Interaction logic for AddProductControl.xaml
    /// </summary>
    public partial class AddProductControl : UserControl
    {

        public AddProductControl()
        {
            InitializeComponent();   
            
            DataContext = new ProductViewModel();        
        }
    }
}
