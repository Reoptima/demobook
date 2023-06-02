using demobook.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demobook.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
