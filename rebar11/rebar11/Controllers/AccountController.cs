using Microsoft.AspNetCore.Mvc;
using rebar11.Data;
using rebar11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rebar11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        private readonly MongoDBContext _context;
        private const string PASSWORD = "Rivka1234";

        public AccountController(MongoDBContext context)
        {
            _context = context;
        }

        [HttpGet("{password}")]
        public ActionResult<ResultData> ClosingCheckout(string password)
        {
            int sumOrdersToday;
            double sumPriceToday = 0;

            if (password.Equals(PASSWORD))
            {
                var ordersToday = _context.TodayOrders();
                sumOrdersToday = ordersToday.Count;
                foreach (var order in ordersToday)
                {
                    foreach (var shake in order.OrderShakes)
                    {
                        sumPriceToday += shake.Price * (1 - shake.Discount.Percent / 100);
                    }
                }
                _context.AddAccount(sumOrdersToday, sumPriceToday);


                return Ok(new ResultData
                {
                    SumOrdersToday = sumOrdersToday,
                    SumPriceToday = sumPriceToday
                });
            }
            else
            {
                return BadRequest("The password is incorrect.");
            }
        }

        
    }
}
