using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySQLWebserver.Models;

namespace MySQLWebserver.Controllers
{
    [Route("api/[controller]")]
    public class ActorController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private AppDbContext dbContext;
        public ActorController()
        {
            string DefaultConnection = "server=localhost; port=3306; database=sakila; userid=root; pwd=123456; sslmode=none";
            dbContext = AppDbContextFactory.Create(DefaultConnection); 
        }

        /// <summary>
        /// obtain the list/index of all actors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Actor.ToArrayAsync());
        }

        /// <summary>
        /// obtain actor information by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null)
                return NotFound();
            var actor = await dbContext.Actor.SingleOrDefaultAsync(a => a.actor_id == id);
            if (actor == null)
                return NotFound();
            else
                return Ok(actor);
        }
       

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Actor actor)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            dbContext.Actor.Add(actor);
            await dbContext.SaveChangesAsync();
            return Created($"api/[controller]", actor);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Actor actor)
        {
            //if (id != actor.actor_id)
            //    return NotFound();
            var _actor =await dbContext.Actor.SingleOrDefaultAsync(a => a.actor_id == id);
            if (!ModelState.IsValid || _actor == null)
            {
                return BadRequest();
            }
            dbContext.Entry(_actor).CurrentValues.SetValues(actor);
            await dbContext.SaveChangesAsync();
            return Ok();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var toDelete = await dbContext.Actor.FindAsync(id);
            if (toDelete != null)
            {
                dbContext.Actor.Remove(toDelete);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            else
                return NotFound();

        }
    }
}