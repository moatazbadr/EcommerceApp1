using EcommerceApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.classes
{
    public class Biscuits : Product, IShippable, IExpirable
    {
        public Biscuits( string name,decimal price ,int quantity, DateTime expirationDate, double weighInKg)
            : base(name, price, quantity)
        {
            ExpirationDate = expirationDate;
            this.weighInKg = weighInKg;
        }

        public DateTime ExpirationDate { get ; set ; }

        public double weighInKg { get; set; }
      

        public string GetName()
        {
            return Name;
        }

        public double GetWeight()
        {
            return weighInKg;
        }
    }
}
