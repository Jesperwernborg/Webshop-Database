using System;
using System.Collections.Generic;

namespace webshop
{
    public class Order
    {
        public int Id { get; set; }
        public int companyId { get; set; }
        public int totalPrice { get; set; }
        public string status { get; set; }
        public string paymentMethod { get; set; }
        public DateTime created { get; set; }
        public string createdBy { get; set; }
        
        ICollection<Order> Orders { get; set; }
    }
}
