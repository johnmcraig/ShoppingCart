using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Data
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Product Products { get; set; }
    }
}
