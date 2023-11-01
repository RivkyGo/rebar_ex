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


        //[HttpGet]
        //public string Get()
        //{
        //    return "[]";
        //}

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(Guid id)
        {
            var order = _context.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //[HttpGet("{ShakeName}")]
        //public ActionResult<Shake> CreateOrder()
        //{

        //}

        //[HttpGet]
        //public async Task<IEnumerable<Order>> Get()
        //{
        //    return await _context.Orders.Find(_ => true).ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Order>> Get(Guid id)
        //{
        //    var product = await _context.Orders.Find(p => p.OrderID == id).FirstOrDefaultAsync();

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return product;
        //}

        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {

            if (order == null)
            {
                return BadRequest("The input is incorrect");
            }
            if (order.OrderShakes.Count > 10)
            {
                return BadRequest("An order cannot contain more than 10 items");
            }

            order.OrderDateTime = DateTime.Now; /// לא בטוחה שזה טוב אולי צריך יום 
            order.OrderID = Guid.NewGuid();
            foreach (var shake in order.OrderShakes)
            {
                ShakeMenu shakeMenu = _context.GetShakeMenu(shake.ShakeName);
                if (shakeMenu == null)
                {
                    return BadRequest("You asked for a shake that is not on the menu.");
                }
                if (shake.ShakeSize.Equals("S"))
                {
                    shake.Price = shakeMenu.ShakeSizeS;
                    order.SumPrice += shake.Price;
                }
                else if (shake.ShakeSize.Equals("M"))
                {
                    shake.Price = shakeMenu.ShakeSizeM;
                    order.SumPrice += shake.Price;
                }
                else if (shake.ShakeSize.Equals("L"))
                {
                    shake.Price = shakeMenu.ShakeSizeL;
                    order.SumPrice += shake.Price;
                }
                else
                {
                    return BadRequest("the size isn't correct");
                }
            }

            _context.AddOrder(order);

            return Ok("order save seccesfuly");
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id, Order orderIn)
        //{
        //    var product = await _context.Orders.Find(p => p.OrderID == id).FirstOrDefaultAsync();

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    await _context.Orders.ReplaceOneAsync(p => p.OrderID == id, orderIn);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var product = await _context.Orders.Find(p => p.OrderID == id).FirstOrDefaultAsync();

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    await _context.Orders.DeleteOneAsync(p => p.OrderID == id);

        //    return NoContent();
        //}
    }
}
