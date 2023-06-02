using demobook.Models;
using demobook.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace demobook
{
    /// <summary>
    /// Логика взаимодействия для GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        private int _userId;

        public GuestWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadProducts();
        }

        public GuestWindow()
        {
        }

        private void LoadProducts()
        {
            List<Product> products = DataAccess.GetProducts();
            lbProducts.ItemsSource = products;
        }

        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (lbProducts.SelectedItem is Product selectedProduct)
            {
                int productId = selectedProduct.ProductId;
                DataAccess.PlaceOrder(_userId, productId);
                MessageBox.Show("Order placed successfully!");
            }
        }
    }
}
