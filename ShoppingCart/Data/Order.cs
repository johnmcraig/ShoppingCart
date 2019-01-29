using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Data
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Price { get; set; }
        public bool Paid { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
