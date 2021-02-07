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
    public class OrdersController : ControllerBase
    {
        private readonly WebshopContext _context;
        private readonly IMapper _mapper;

        public OrdersController(WebshopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        
        public async Task<ActionResult> GetOrders()
        {
            List<Order> orders = await _context.Orders.Include(o => o.Order_Details).ToListAsync();

            List<OrderDTO> orderDTOs = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(orderDTOs);
        }

        // GET: api/Orders/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            Order found = await _context.Orders.FindAsync(id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OrderDTO>(found));
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostOrder([FromBody]OrderDTO newOrderDTO)
        {
            Order newOrder = _mapper.Map<Order>(newOrderDTO);
            
            newOrder.created = DateTime.Now;
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostOrder", newOrder);
        } 
        

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
