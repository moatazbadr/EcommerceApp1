using EcommerceApp.classes;

namespace EcommerceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Moataz", 200m);
            Console.WriteLine($"Welcome to Ecommerce App {customer.customerName} !");
            Console.WriteLine("products avialble : Cheese , Biscuits ,TVs and MobileScratchCard");
            Console.WriteLine();
            List<Product> products = new List<Product>()
            {
                 new Cheese("Cheddar Cheese", 20, 5, DateTime.UtcNow.AddDays(5), 0.25),
                new Biscuits("Biscuits", 10, 10, DateTime.UtcNow.AddDays(1), 0.4),
                new Tv("Samsung TV", 150, 2, 3),
                new MobileScratchCard("Mobile Card", 25, 100)

            };



            int key;
            do
            {
                Console.WriteLine("\nPlease enter the product to add:");
                Console.WriteLine("1: Cheese\n2: Biscuits\n3: TVs\n4: Mobile Scratch Card\n5: Checkout");
                Console.Write("Your choice: ");

                bool parsing = int.TryParse(Console.ReadLine(), out key);

                if (!parsing || key < 1 || key > 5)
                {
                    Console.WriteLine("Please enter a valid number between 1 and 5.");
                    continue;
                }

                if (key == 5)
                    break;

                var product = products[key - 1];
                Console.Write($"Enter quantity for {product.Name}: ");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    try
                    {
                        customer.cart.AddItem(product, quantity);
                        Console.WriteLine($" Added {quantity} x {product.Name} to cart.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($" Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine(" Invalid quantity input.");
                }

            } while (true);

            try
            {
                customer.Checkout();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error during checkout: {ex.Message}");
            }




        }
    }
}
