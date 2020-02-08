using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using strovollio_api.Models;
using System;

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
            var orders = await _context.Orders.ToListAsync();
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
        public async Task<IActionResult> CreateOrderByMerchantID(Guid ID, Order order)
        {
            var merchantByID = await _context.Merchants.FirstOrDefaultAsync( merchant => merchant.MerchantID == ID);
            var orderToCreate = new Order {
                MerchantID = merchantByID.MerchantID,
                Merchant = merchantByID,
                MenuItems = order.MenuItems
            };
            await _context.Orders.AddAsync(orderToCreate);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}