using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.classes
{
    public class CartItem
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return product.price * Quantity;
            }
        }
        public CartItem(Product product, int quantity)
        {
            this.product = product;
            Quantity = quantity;
        }
    }
}
