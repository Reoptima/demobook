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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        private AdminViewModel viewModel;

        public AdminWindow()
        {
            InitializeComponent();
            viewModel = new AdminViewModel();
            DataContext = viewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.LoadProducts();
            viewModel.LoadOrders();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            viewModel.CreateProduct(productName);
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateProduct();
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteProduct();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            int userId = int.Parse(txtUserId.Text);
            int productId = int.Parse(txtProductId.Text);
            DateTime orderDate = dpOrderDate.SelectedDate ?? DateTime.Now;
            viewModel.CreateOrder(userId, productId, orderDate);
        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateOrder();
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteOrder();
        }
    }
}