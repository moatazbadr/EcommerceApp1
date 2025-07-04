using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Interfaces
{
    public interface IExpirable
    {
        DateTime ExpirationDate { get; set; }
        bool IsExpired=> ExpirationDate < DateTime.UtcNow.Date;
    }
}
