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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            LoadProducts();
            LoadOrders();
        }

        private void LoadProducts()
        {
            List<Product> products = DataAccess.GetProducts();
            dgProducts.ItemsSource = products;
        }

        private void LoadOrders()
        {
            List<Order> orders = DataAccess.GetOrders();
            dgOrders.ItemsSource = orders;
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selectedProduct)
            {
                string newProductName = txtProductName.Text;
                selectedProduct.ProductName = newProductName;
                DataAccess.UpdateProduct(selectedProduct);
                MessageBox.Show("Product updated successfully!");
                LoadProducts();
            }
        }
    }
}