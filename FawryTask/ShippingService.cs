using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    class ShippingService
    {
        public void ShipItems(List<IShippable> items)
        {
            Console.WriteLine("Shipping the following items:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.getName()} ({item.getWeight()} kg)");
            }
        }

        public double CalculateShippingFee(List<IShippable> items)
        {
            return items.Sum(i => i.getWeight()) * 10; // Example rate: 10 LE per KG
        }

    }
}
