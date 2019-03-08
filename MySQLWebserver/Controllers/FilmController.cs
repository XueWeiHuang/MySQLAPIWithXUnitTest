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
    public class FilmController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private AppDbContext dbContext;
        public FilmController()
        {
            string DefaultConnection = "server=localhost; port=3306; database=sakila; userid=root; pwd=123456; sslmode=none";
            dbContext = AppDbContextFactory.Create(DefaultConnection);

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Film.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var film = await dbContext.Film.SingleOrDefaultAsync(p => p.Film_ID == id);
            return Ok(film);
        }


          
    }
}