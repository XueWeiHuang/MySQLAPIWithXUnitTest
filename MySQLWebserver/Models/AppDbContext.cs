
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.EntityFrameworkCore.Extensions;



namespace MySQLWebserver.Models
{
    public class AppDbContext:DbContext
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {            
        }
        public DbSet<Film> Film { get; set; }
        public DbSet<Actor> Actor { get; set; }
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
