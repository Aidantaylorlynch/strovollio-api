using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using strovollio_api.Models;
using System;
using System.Linq;
using strovollio_api.ViewModels;
using System.Collections.Generic;

namespace strovollio_api
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private StrovollioDbContext _context;
        public OrderController(StrovollioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Orders.Include(includeMenuItems => includeMenuItems.MenuItems).ToListAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderByID(Guid ID)
        {
            var orderByID = await _context.Orders.Include(includeMenuItems => includeMenuItems.MenuItems).FirstOrDefaultAsync( order => order.OrderID == ID);
            return Ok(orderByID);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> CreateOrderByMerchantID(Guid ID, OrderViewModel orderViewModel)
        {
            var merchantByID = await _context.Merchants.FirstOrDefaultAsync( merchant => merchant.MerchantID == ID);
            var orderToCreate = new Order {
                MerchantID = merchantByID.MerchantID,
                Merchant = merchantByID
            };
            orderToCreate.MenuItems = new List<MenuItem>();
            orderViewModel.MenuItemIDs.ToList().ForEach(async item => orderToCreate.MenuItems.Add(await _context.MenuItems.FirstOrDefaultAsync(menuItem => menuItem.MenuItemID == item)));
            await _context.Orders.AddAsync(orderToCreate);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}