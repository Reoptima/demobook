using demobook.Models;
using demobook.utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace demobook
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> products;
        private Product selectedProduct;
        private ObservableCollection<Order> orders;
        private Order selectedOrder;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged(); }
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Order> Orders
        {
            get { return orders; }
            set { orders = value; OnPropertyChanged(); }
        }

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; OnPropertyChanged(); }
        }

        public void LoadProducts()
        {
            Products = new ObservableCollection<Product>(DataAccess.GetProducts());
        }

        public void LoadOrders()
        {
            Orders = new ObservableCollection<Order>(DataAccess.GetOrders());
        }

        public void CreateProduct(string productName)
        {
            DataAccess.CreateProduct(productName);
            LoadProducts();
        }

        public void UpdateProduct()
        {
            if (SelectedProduct != null)
            {
                DataAccess.UpdateProduct(SelectedProduct);
                LoadProducts();
            }
        }

        public void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                DataAccess.DeleteProduct(SelectedProduct);
                LoadProducts();
            }
        }

        public void CreateOrder(int userId, int productId, DateTime orderDate)
        {
            DataAccess.CreateOrder(userId, productId, orderDate);
            LoadOrders();
        }

        public void UpdateOrder()
        {
            if (SelectedOrder != null)
            {
                DataAccess.UpdateOrder(SelectedOrder);
                LoadOrders();
            }
        }

        public void DeleteOrder()
        {
            if (SelectedOrder != null)
            {
                DataAccess.DeleteOrder(SelectedOrder);
                LoadOrders();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
