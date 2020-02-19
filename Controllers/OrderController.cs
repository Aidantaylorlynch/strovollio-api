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
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderByID(Guid ID)
        {
            var orderByID = await _context.Orders.FirstOrDefaultAsync( order => order.OrderID == ID);
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
            orderToCreate.LineItems = new List<LineItem>();
            orderViewModel.MenuItemIDs.ToList().ForEach(menuItemID => orderToCreate.LineItems.Add(new LineItem(orderToCreate.OrderID, menuItemID)));
            await _context.Orders.AddAsync(orderToCreate);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}