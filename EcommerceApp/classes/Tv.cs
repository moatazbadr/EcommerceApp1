using EcommerceApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.classes
{
    public class Tv : Product, IShippable
    {
        public double WeightInKg { get; set; }
        public Tv( string name, decimal price, int quantity, double weightInKg) : base(name, price, quantity)
        {
            WeightInKg = weightInKg;
        }
        public string GetName()
        {
            return Name;
        }

        public double GetWeight()
        {
            return WeightInKg;
        }
    }
}
