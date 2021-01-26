using System;
using System.Collections.Generic;

namespace webshop
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        

        ICollection<Product> Products { get; set; }
    }
}







