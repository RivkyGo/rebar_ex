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
    public class MenuController : ControllerBase
    {



        private readonly MongoDBContext _context;

        public MenuController(MongoDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult<IEnumerable<ShakeMenu>> GetMenu()
        {
            try
            {
                var menuItems = _context.GetMenu();
                if (menuItems == null)
                {
                    return NotFound(); 
                }

                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }




        // GET: api/Menu/{id}
        //[HttpGet("{id:length(24)}", Name = "GetShake")]
        [HttpGet("{id}")]
        public ActionResult<ShakeMenu> Get(string id)
        {
            var shake = _context.GetShakeById(new Guid(id));

            if (shake == null)
            {
                return NotFound();
            }

            return shake;
        }

        // POST api/<MenuController>
        [HttpPost]
        public ActionResult<ShakeMenu> Post([FromBody] ShakeMenu shakeMenu)
        {
            shakeMenu.ShakeID = Guid.NewGuid();
            _context.AddShakeMenu(shakeMenu);
            //return CreatedAtRoute("GetShake", new { id = shakeMenu.ShakeID.ToString() }, shakeMenu);
            return Ok("The shake has been successfully added to the menu");
        }

    }
}
