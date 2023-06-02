using demobook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demobook.utils
{
    public class DataAccess
    {
        public static int AuthenticateUser(string username, string password)
        {
            using (var context = new BookStoreContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    return user.UserId;
                }
                return 0;
            }
        }

        public static int GetRoleId(string username)
        {
            using (var context = new BookStoreContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                return user?.RoleId ?? 0;
            }
        }

        public static void PlaceOrder(int userId, int productId)
        {
            using (var context = new BookStoreContext())
            {
                var order = new Order
                {
                    UserId = userId,
                    ProductId = productId,
                    OrderDate = DateTime.Now
                };
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public static List<Product> GetProducts()
        {
            using (var context = new BookStoreContext())
            {
                return context.Products.ToList();
            }
        }

        public static void CreateProduct(string productName)
        {
            using (var context = new BookStoreContext())
            {
                var product = new Product
                {
                    ProductName = productName
                };
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public static void UpdateProduct(Product product)
        {
            using (var context = new BookStoreContext())
            {
                var existingProduct = context.Products.Find(product.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteProduct(Product product)
        {
            using (var context = new BookStoreContext())
            {
                var existingProduct = context.Products.Find(product.ProductId);
                if (existingProduct != null)
                {
                    context.Products.Remove(existingProduct);
                    context.SaveChanges();
                }
            }
        }

        public static List<Order> GetOrders()
        {
            using (var context = new BookStoreContext())
            {
                return context.Orders.Include(o => o.User).Include(o => o.Product).ToList();
            }
        }

        public static void CreateOrder(int userId, int productId, DateTime orderDate)
        {
            using (var context = new BookStoreContext())
            {
                var order = new Order
                {
                    UserId = userId,
                    ProductId = productId,
                    OrderDate = orderDate
                };
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public static void UpdateOrder(Order order)
        {
            using (var context = new BookStoreContext())
            {
                var existingOrder = context.Orders.Find(order.OrderId);
                if (existingOrder != null)
                {
                    existingOrder.UserId = order.UserId;
                    existingOrder.ProductId = order.ProductId;
                    existingOrder.OrderDate = order.OrderDate;
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteOrder(Order order)
        {
            using (var context = new BookStoreContext())
            {
                var existingOrder = context.Orders.Find(order.OrderId);
                if (existingOrder != null)
                {
                    context.Orders.Remove(existingOrder);
                    context.SaveChanges();
                }
            }
        }
    }
}
