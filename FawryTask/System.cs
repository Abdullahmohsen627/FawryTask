using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    class System
    {
        private ShippingService shippingService = new ShippingService();

        public void Checkout(Customer customer)
        {
            if (customer.Cart.Count == 0)
            {
                Console.WriteLine("Error: Cart is empty.");
                return;
            }

            foreach (var item in customer.Cart)
            {
                if (item.Product is Shipable_ExpProduct perishable && perishable.IsExpired())
                {
                    Console.WriteLine($"Error: Product '{perishable.Name}' is expired.");
                    return;
                }

                if (item.Quantity > item.Product.Quantity)
                {
                    Console.WriteLine($"Error: Product '{item.Product.Name}' is out of stock.");
                    return;
                }
            }

            double subtotal = customer.Cart.Sum(i => i.Product.Price * i.Quantity);

            var shippableItems = customer.Cart
                .Where(i => i.Product is IShippable)
                .Select(i => (IShippable)i.Product)
                .ToList();

            double shippingFee = shippingService.CalculateShippingFee(shippableItems);
            double total = subtotal + shippingFee;

            if (customer.Balance < total)
            {
                Console.WriteLine("Error: Insufficient balance.");
                return;
            }
            Console.WriteLine($"Subtotal: {subtotal} LE");
            Console.WriteLine($"Shipping Fee: {shippingFee} LE");
            Console.WriteLine($"Total Paid: {total} LE");

            customer.Balance -= total;
            Console.WriteLine($"Remaining Balance: {customer.Balance} LE");

            foreach (var item in customer.Cart)
            {
                item.Product.Quantity -= item.Quantity;
            }

            if (shippableItems.Any())
            {
                shippingService.ShipItems(shippableItems);
            }

            customer.Cart.Clear();
        }
    }

}