using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using strovollio_api.Models;
using System;

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
        [Route("{id}/menu")]
        public async Task<IActionResult> GetMenuByMerchantID(Guid ID)
        {
            var menuByMerchantID = await _context.Menus.Include(includeMenuItems => includeMenuItems.MenuItems).FirstOrDefaultAsync(menu => menu.MerchantID == ID);
            return Ok(menuByMerchantID);
        }

        [HttpPost]
        [Route("{id}/menu")]
        public async Task<IActionResult> CreateMenuByMerchantID(Guid ID, Menu menu)
        {
            var menuByMerchantID = await _context.Menus.FirstOrDefaultAsync(menu => menu.MerchantID == ID);
            menu.MerchantID = ID;
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
            return Ok(menuByMerchantID);
        }
    }
}