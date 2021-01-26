using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace webshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ProductContext _context;
        public OrderDetailsController(ProductContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<OrderDetail>> GetOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        [HttpPost]
        public async Task<OrderDetail> CreateOrderDetail(OrderDetail newOrderDetail)
        {
            _context.OrderDetails.Add(newOrderDetail);
            await _context.SaveChangesAsync();

            return newOrderDetail;
        }
    }
}
