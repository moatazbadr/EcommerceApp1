using EcommerceApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.classes
{
    public class Cheese : Product, IShippable, IExpirable
    {
        public DateTime ExpirationDate { get ; set ; }
        public double weighInKg { get; set; }

        public Cheese(string name, decimal price, int quantity, DateTime expirationDate ,double weight)
            : base(name, price, quantity)
        {
            ExpirationDate = expirationDate;
            this.weighInKg = weight;
        }
        public string GetName()
        {
            return this.Name;
        }

        public double GetWeight()
        {
            return this.weighInKg;
        }
    }
}
