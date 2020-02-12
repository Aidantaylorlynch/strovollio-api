using System.Collections.Generic;
using strovollio_api.Models;
using System;

namespace strovollio_api.ViewModels
{
    public class OrderViewModel
    {
        public Guid MerchantID { get; set; }
        public ICollection<Guid> MenuItemIDs { get; set; }
    }
}