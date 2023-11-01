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

        public AccountController(MongoDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<ResultData> ClosingCheckout(string id)
        {
            int sumOrdersToday;
            double sumPriceToday = 0;

            if (id.Equals("Rivka1234"))
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

        //// GET: api/<AccountController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<AccountController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<AccountController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<AccountController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AccountController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
