using System.Collections.Generic;
using strovollio_api.Models;

namespace strovollio_api.ViewModels
{
    public class MenuItemsViewModel
    {
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}