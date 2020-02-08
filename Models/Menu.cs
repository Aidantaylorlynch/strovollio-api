using System;
using System.Collections.Generic;

namespace strovollio_api.Models
{
    public class Menu
    {
        public Menu()
        {
            this.MenuID = Guid.NewGuid();
        }

        public Guid MenuID { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public Merchant Merchant { get; set; }
        public Guid MerchantID { get; set; }
    }
}