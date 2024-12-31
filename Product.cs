using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class Product
    {
       private static readonly Random random = new Random();
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int ProductId { get; set; }    
        public string? ProductName { get; set; }

        public double? Price { get; set; }

        public Product(string productname, double price, string category, string description)
        {
            ProductName = productname;
            Price = price;
            Category = category;
            Description = description;
            ProductId = random.Next(ProductId);
        }


    }
}
