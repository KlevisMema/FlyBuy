using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyBuy.Models
{
    public class Cart
    {
        public  Product Product { get; set; }

        public int Quantity { get; set; }
        
        public Cart (Product p , int q)
        {
            Product = p;
            Quantity = q;
        }
        
    }
}