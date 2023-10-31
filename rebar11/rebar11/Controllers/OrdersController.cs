using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;
//using System.Collections.Generic;
//using System.Threading.Tasks;
using rebar11.Data;
using rebar11.Models;

namespace rebar11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public OrdersController(MongoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.Orders.Find(_ => true).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(Guid id)
        {
            var product = await _context.Orders.Find(p => p.OrderID == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create(Order order)
        {
            await _context.Orders.InsertOneAsync(order);
            return CreatedAtRoute(new { id = order.OrderID }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Order orderIn)
        {
            var product = await _context.Orders.Find(p => p.OrderID == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            await _context.Orders.ReplaceOneAsync(p => p.OrderID == id, orderIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _context.Orders.Find(p => p.OrderID == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            await _context.Orders.DeleteOneAsync(p => p.OrderID == id);

            return NoContent();
        }
    }
}
