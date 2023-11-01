using System;
using Microsoft.AspNetCore.Mvc;
using rebar11.Data;
using rebar11.Models;

namespace rebar11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly MongoDBContext _context;
        private static Account _account = null;

        public OrdersController(MongoDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<Order> GetAllOrders()
        {
            var order = _context.GetAllOrders();
            if (order == null)
            {
                return BadRequest("there is no orders");
            }
            return Ok(order);
        }

        [HttpGet("{orderID}")]
        public ActionResult<Order> GetOrder(Guid orderID)
        {
            var order = _context.GetOrderById(orderID);
            if (order == null)
            {
                return BadRequest("Invalid order ID");
            }
            return Ok(order);
        }

        

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
            if (order.CustomerName == null)
            {
                return BadRequest("The name of the inviter is missing");
            }
            if (order.OrderShakes.Count == 0)
            {
                return BadRequest("You have not ordered any items.");
            }
            order.OrderTimeStart = DateTime.Now;
            
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
            order.OrderTimeFinish = DateTime.Now;
            _context.AddOrder(order);
            if (_account == null)
            {
                _account = new Account();
            }
            _account.Orders.Add(order);
            return Ok("order save seccesfuly");
        }
    }
}
