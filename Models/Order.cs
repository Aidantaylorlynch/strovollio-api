using System;
using System.Collections.Generic;

namespace strovollio_api.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderID = Guid.NewGuid();
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