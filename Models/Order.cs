using System;
using System.Collections.Generic;

namespace strovollio_api.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderID = Guid.NewGuid();
            this.OrderDate = DateTime.Now;
        }

        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public Guid MerchantID { get; set; }
        public Merchant Merchant { get; set; }
    }
}

// need to associate order to merchant
// datetime needs to be init
// route needs to be merchant
// need users id 