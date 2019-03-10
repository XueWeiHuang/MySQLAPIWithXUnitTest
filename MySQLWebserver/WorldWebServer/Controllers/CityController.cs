using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldWebServer.Models;

namespace WorldWebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public CityController()
        {
            var DefaultConnection = "server=localhost; port=3306; database=world; userid=root; pwd=123456; sslmode=none";
            this.appDbContext = AppDbContextFactory.Create(DefaultConnection);
        }
        // GET: api/City
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await appDbContext.City.ToArrayAsync());
        }


        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var city = appDbContext.City.SingleOrDefaultAsync(c => c.ID == id);
            if (id==null || city==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await city);
            }
        }

        [HttpGet("cc/{cc}")]
        public async Task<IActionResult> Get(string cc)
        {
            var city = appDbContext.City.Where(c => c.CountryCode.ToUpper() == cc.ToUpper()).ToArrayAsync();
            return Ok(await city);
        }


        // POST: api/City
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] City city)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            appDbContext.City.Add(city);
            await appDbContext.SaveChangesAsync();
            return Created($"api/city/{city.ID}", city);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [Bind("ID, Name, CountryCode, District, Population")] City city)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var citycopy = appDbContext.City.SingleOrDefault(c => c.ID == id);
            if (citycopy!=null)
            {
                appDbContext.Entry(citycopy).CurrentValues.SetValues(city);
                await appDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }


        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var city = appDbContext.City.SingleOrDefault(c => c.ID == id);
            if (city != null)
            {
                appDbContext.City.Remove(city);
                await appDbContext.SaveChangesAsync();
                return Ok();
            }
            else
                return NotFound();
        }

    }
}
