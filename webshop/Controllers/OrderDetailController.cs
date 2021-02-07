using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webshop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly WebshopContext _context;
        private readonly IMapper _mapper;

        public OrderDetailsController(WebshopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/OrderDetail
        [HttpGet]
        public async Task<ActionResult> GetOrderDetails()
        {
            List<Order_Detail> orderDetails = await _context.OrderDetails.ToListAsync();

            List<Order_DetailDTO> orderDetailDTOs = _mapper.Map<List<Order_DetailDTO>>(orderDetails);

            return Ok(orderDetailDTOs);
        }

        // GET: api/OrderDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderDetail(int id)
        {
            Order_Detail found = await _context.OrderDetails.FindAsync(id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Order_DetailDTO>(found));
        }

        // PUT: api/OrderDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, Order_Detail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostOrderDetail(Order_Detail newOrder_Detail)
        {
            _context.OrderDetails.Add(newOrder_Detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostOrderDetail", newOrder_Detail);
        }

        // DELETE: api/OrderDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}
