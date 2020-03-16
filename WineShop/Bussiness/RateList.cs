using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineShop.Bussiness
{
    public class RateList
    {
        public int ID { get; set; }
        public Nullable<decimal> Price { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
