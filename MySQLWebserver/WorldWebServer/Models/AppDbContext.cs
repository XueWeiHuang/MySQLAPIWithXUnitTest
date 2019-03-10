using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldWebServer.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
    }

    public class AppDbContextFactory
    {
        public static AppDbContext Create(string DefaultConnection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(DefaultConnection);
            var _appDbContext = new AppDbContext(optionsBuilder.Options);
            return _appDbContext;

        }
    }
}
