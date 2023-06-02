using demobook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demobook.utils
{
    public class BookStoreManager
    {
        public List<Product> GetProducts()
        {
            return DataAccess.GetProducts();
        }

        public void PlaceOrder(User user, Product product)
        {
            DataAccess.PlaceOrder(user.UserId, product.ProductId);
        }
    }
}
