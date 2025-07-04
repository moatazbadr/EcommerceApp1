using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.classes
{
    public abstract class Product
    {
        public string Name { get; set; } 
        public decimal price { get; set; }
        public int Quantity { get; set; }
        protected Product(string name, decimal price, int quantity)
        {
            Name = name;
            this.price = price;
            Quantity = quantity;
        }
        public void checkStock(int quantity)
        {
            if (quantity > Quantity || quantity < 1)
            {
                Console.WriteLine($"insufficient quantity for {Name}");
            }
            else
            {
                Quantity -= quantity;
            }
        }

       

    }
}
