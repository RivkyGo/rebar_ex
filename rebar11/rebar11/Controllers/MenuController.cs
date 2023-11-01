using Microsoft.AspNetCore.Mvc;
using rebar11.Data;
using rebar11.Models;
using System;
using System.Collections.Generic;



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



        [HttpGet("{shakeID}")]
        public ActionResult<ShakeMenu> Get(string shakeID)
        {
            Guid guidShakeID;
            if (Guid.TryParse(shakeID, out guidShakeID))
            {
                var shake = _context.GetShakeById(guidShakeID);

                if (shake == null)
                {
                    return BadRequest("there is no this shake");
                }

                return shake;
            }
            else
            {
                return BadRequest("The provided shakeID is not a valid GUID.");
            }
        }


        [HttpPost]
        public ActionResult<ShakeMenu> Post([FromBody] ShakeMenu shakeMenu)
        {
            shakeMenu.ShakeID = Guid.NewGuid();
            _context.AddShakeMenu(shakeMenu);
            return Ok("The shake has been successfully added to the menu");
        }

    }
}
