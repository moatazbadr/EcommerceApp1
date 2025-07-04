using EcommerceApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Services
{
    public static class ShippingService
    {
        public static void ShipToCustomer(List<IShippable> shippables)
        {
            if (shippables == null || !shippables.Any())
            {
                Console.WriteLine("No items to ship.");
                return;
            }
            Console.WriteLine("Shipping the following items:");
            foreach (var item in shippables)
            {
                Console.WriteLine($" {item.GetName()}");
            }
           // Console.WriteLine("Items have been shipped successfully!");
        }
    }
}
