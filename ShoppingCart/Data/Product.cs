using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Data
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
