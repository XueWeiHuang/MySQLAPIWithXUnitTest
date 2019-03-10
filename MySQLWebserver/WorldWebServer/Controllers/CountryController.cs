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
    public class CountryController : ControllerBase
    {
        private AppDbContext appDbContext;
        public CountryController()
        {
            var DefaultConnection = "server=localhost; port=3306; database=world; userid=root; pwd=123456; sslmode=none";
            this.appDbContext = AppDbContextFactory.Create(DefaultConnection);
        }

        // GET: api/Country
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await appDbContext.Country.ToArrayAsync());
        }


        // GET: api/Country/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
