using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineShop.Bussiness
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public Nullable<int> RateListID { get; set; }
        public Nullable<int> WineID { get; set; }

        public virtual RateList RateList { get; set; }
        public virtual Wine Wine { get; set; }
    }
}
