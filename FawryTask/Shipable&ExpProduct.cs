using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    class Shipable_ExpProduct : ExpiryProduct, IShippable
    {
        public double Weight { get; set; }
        public string getName() => Name;
        public double getWeight() => Weight;
    }
}
