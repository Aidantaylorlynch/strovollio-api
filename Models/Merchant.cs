using System;
using System.Collections.Generic;

namespace strovollio_api.Models
{
    public class Merchant
    {
        public Merchant(string email, string name)
        {
            this.MerchantID = Guid.NewGuid();
            this.Email = email;
            this.Name = name;
        }

        public Guid MerchantID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public string TestMigration { get; set; }
    }
}