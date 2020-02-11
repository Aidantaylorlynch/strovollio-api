using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using strovollio_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using strovollio_api.ViewModels;

namespace strovollio_api
{
    [ApiController]
    [Route("api/merchants")]
    public class MerchantController : ControllerBase
    {
        private StrovollioDbContext _context;
        public MerchantController(StrovollioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetMerchants()
        {
            var merchants = await _context.Merchants.ToListAsync();
            return Ok(merchants);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMerchantByID(Guid ID)
        {
            var merchantByID = await _context.Merchants.FirstOrDefaultAsync( merchant => merchant.MerchantID == ID);
            return Ok(merchantByID);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateMerchant(Merchant merchant)
        {
            await _context.Merchants.AddAsync(merchant);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMerchantByID), new { id = merchant.MerchantID }, merchant);
        }

        [HttpGet]
        [Route("{id}/menuitems")]
        public async Task<IActionResult> GetMenuItemsByMerchantID(Guid ID)
        {
            var menuItemsMerchantID = await _context.MenuItems.Where(menuItem => menuItem.MerchantID == ID).ToListAsync();
            var menuItems = new MenuItemsViewModel();
            menuItems.MenuItems = menuItemsMerchantID;
            return Ok(menuItems);
        }

        [HttpPost]
        [Route("{id}/menuitems")]
        public async Task<IActionResult> CreateMenuByMerchantID(Guid ID,  MenuItemsViewModel menuItemsViewModel)
        {
            var menuItems = menuItemsViewModel.MenuItems.Select(menuItem => new MenuItem(
                menuItem.Name, menuItem.Description, menuItem.Price, menuItem.MerchantID
            )).ToList();
            _context.MenuItems.AddRange(menuItems);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}