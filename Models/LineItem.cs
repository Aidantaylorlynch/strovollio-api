using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace strovollio_api.Models
{
    public class LineItem
    {
        public LineItem(Guid orderID, Guid menuItemID) {
            this.LineItemID = Guid.NewGuid();
            this.OrderID = orderID;
            this.MenuItemID = menuItemID;
        }
        public Guid LineItemID { get; set; }
        public Guid OrderID { get; set; }
        public Guid MenuItemID { get; set; }
    }
}
