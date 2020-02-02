using System;

namespace strovollio_api.Models
{
    public class MenuItem
    {
        public MenuItem(string name, string description, int price)
        {
            this.MenuItemID = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public Guid MenuItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Guid MenuID { get; set; }
        public Menu Menu { get; set; }
    }
}