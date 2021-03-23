using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public class FictionDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        private IConfiguration _configuration;

        public FictionDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBulder)
        {
            optionsBulder.UseSqlServer(_configuration.GetConnectionString("FictionDbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character() { Id = 1, Age = 2, Name = "Atest" },
                new Character() { Id = 2, Age = 22, Name = "Btest" },
                new Character() { Id = 3, Age = 12, Name = "Ctest" });
        }
    }
}
