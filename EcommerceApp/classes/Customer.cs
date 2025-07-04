using EcommerceApp.Interfaces;
using EcommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.classes
{
    public class Customer
    {
        public string customerName { get; set; }
        public decimal balance { get; set; }
        public Cart cart { get; set; } = new Cart();
        public Customer(string customerName, decimal balance)
        {
            this.customerName = customerName;
            this.balance = balance;
        }
        public void Checkout()
        {
            if (!cart.items.Any())
                throw new InvalidOperationException("Cart is empty");
            var removedItems = cart.RemoveExpiredItemsAndReturnThem();
            if (removedItems.Any())
            {
                Console.WriteLine("The following items have been removed from your cart because of expireation: ");
                foreach (var item in removedItems)
                {
                    Console.WriteLine($"{item.product.Name} - {item.Quantity} units");
                }
                Console.WriteLine("----------------------------------");
            }
           if(!cart.items.Any())
                throw new InvalidOperationException("your Cart is empty after removing expired items");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("please note that orders above 100usd gets free shipping");
            decimal subTotal = cart.SubTotal;
            double totalWeight= cart.TotalWeight;
            double shippingCost = 0;
            foreach (var cartItem in cart.shippablesItems)
            {
                shippingCost += cartItem.GetWeight() * 5 ;
            }
            if (subTotal >= 100)
            {
                shippingCost = 0; 
            }
            decimal totalCost = subTotal + (decimal)shippingCost;
            if (totalCost > balance)
            {
                throw new InvalidOperationException("Insufficient balance to complete the purchase");
            }
            balance -= totalCost;
            Console.WriteLine("\n** Shipment notice **");
            foreach (var item in cart.items.Where(i => i.product is IShippable))
            {
                var product = (IShippable)item.product;
                double totalGrams = product.GetWeight() * 1000 * item.Quantity;
                Console.WriteLine($"{item.Quantity}x {product.GetName()}\t{totalGrams}g");
            }
            Console.WriteLine($"Total package weight {totalWeight:F1}kg\n");
            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.items)
                Console.WriteLine($"{item.Quantity}x {item.product.Name}\t{item.TotalPrice}");

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal\t\t{subTotal}");
            Console.WriteLine($"Shipping\t\t{shippingCost}");
            Console.WriteLine($"Amount\t\t\t{totalCost}");
            if (cart.shippablesItems.Any())
                ShippingService.ShipToCustomer(cart.shippablesItems.Select(i => (IShippable)i).ToList());



        }


    }
}
