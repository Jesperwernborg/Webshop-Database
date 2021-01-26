using System;
using System.Collections.Generic;

namespace webshop
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Orders { get; set; }
        
        public int Amount { get; set; }

        ICollection<Product> Products { get; set; }
        
    }
}