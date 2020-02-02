using System;
using System.Collections.Generic;

namespace strovollio_api.Models
{
    public class Order
    {
        public Order(ICollection<MenuItem> menuItems, User user, Merchant merchant)
        {
            this.OrderID = Guid.NewGuid();
            this.MenuItems = menuItems;
            this.UserID = user.UserID;
            this.User = user;
            this.MerchantID = merchant.MerchantID;
            this.Merchant = merchant;
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