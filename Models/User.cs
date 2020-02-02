using System;
using System.Collections.Generic;

namespace strovollio_api.Models
{
    public class User
    {
        public User(string email, string name)

        {
            this.UserID = Guid.NewGuid();
            this.Email = email;
            this.Name = name;
        }
        
        public Guid UserID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}